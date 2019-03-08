using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance = null;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] closestSpawnPoints;
    private GameObject[] circles;
    public float checkTiming;
    public bool on;
    public GameObject circlePrefab;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Time.time % checkTiming <= Time.deltaTime && on)
        {
            AddPenguins();
        }
    }

    public List<Poolable> levelElements = new List<Poolable>();
    public List<Poolable> holes = new List<Poolable>();

    public void GenerateLevel(LevelData data)
    {
        List<Transform> tempSpawnList = new List<Transform>();
        if (data.id <= 5)
        {
            tempSpawnList = closestSpawnPoints.ToList<Transform>();
        }
        else
        {
            tempSpawnList = spawnPoints.ToList<Transform>();
        }

        if (data.id == 1)
        {
            circles = new GameObject[data.nbrOfFlags];
        }

        for (int i = 0; i < data.nbrOfFlags; i++)
        {
            int r = Random.Range(0, tempSpawnList.Count);
            Transform spawnPoint = tempSpawnList[r];
            Vector3 spawnPosition = GetRandomPositionFromSpawnpoint(spawnPoint);

            levelElements.Add(PoolManager.instance.CreateObject(Poolables.Flag, spawnPosition, Vector3.one));

            tempSpawnList.RemoveAt(r);
            CheckList(ref tempSpawnList);

            if (data.id == 1)
            {
                circles[i] = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
            }
        }

        for (int i = 0; i < data.baseNbrOfPenguins; i++)
        {
            int r = Random.Range(0, tempSpawnList.Count);
            Transform spawnPoint = tempSpawnList[r];
            Vector3 spawnPosition = GetRandomPositionFromSpawnpoint(spawnPoint);

            levelElements.Add(PoolManager.instance.CreateObject(Poolables.Penguin, spawnPosition, Vector3.one));

            tempSpawnList.RemoveAt(r);
            CheckList(ref tempSpawnList);
        }
    }

    private void AddPenguins()
    {
        if (levelElements.Count >= 4 || GameManager.Instance.currentScore >= GameManager.Instance.currentLevel.scoreGoal) { return; }

        Transform spawnPoint = spawnPoints[0];

        foreach (Transform point in spawnPoints)
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, point.position) > 20f)
            {
                spawnPoint = point;
                break;
            }
        }

        Vector3 spawnPosition = GetRandomPositionFromSpawnpoint(spawnPoint);

        levelElements.Add(PoolManager.instance.CreateObject(Poolables.Penguin, spawnPosition, Vector3.one));
    }

    private Vector3 GetRandomPositionFromSpawnpoint(Transform spawnPoint)
    {
        Vector2 randomInRange = Random.insideUnitCircle;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomInRange.x, 0, randomInRange.y) * 5f;
        return spawnPosition;
    }

    private void CheckList(ref List<Transform> list)
    {
        if (list.Count > 0) return;

        else list = spawnPoints.ToList<Transform>();
    }

    public void AddElement(Poolable element)
    {
        levelElements.Add(element);
    }

    public void AddElementHole(Poolable element)
    {
        holes.Add(element);
    }

    public void RemoveElement(Poolable element)
    {
        if (levelElements.Contains(element))
        {
            levelElements.Remove(element);
        }
        else if (holes.Contains(element))
        {
            holes.Remove(element);
        }
    }

    public void ClearLevel()
    {
        print("Clear !");
        int c = levelElements.Count;
        for (int i = 0; i < c; i++)
        {
             PoolManager.instance.DestroyObject(levelElements[0]);
        }

        int h = holes.Count;
        for (int i = 0; i < h; i++)
        {
            PoolManager.instance.DestroyObject(holes[0]);
        }

        if (circles != null)
        {
            foreach (GameObject circle in circles)
            {
                Destroy(circle);
            }
            circles = null;
        }

    }
}
