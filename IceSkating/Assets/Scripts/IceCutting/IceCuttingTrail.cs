using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCuttingTrail : MonoBehaviour
{
    private List<GameObject> trailNodes = new List<GameObject>();
    public GameObject nodePrefab;
    public Transform nodeSpawner;
    public float spawnInterval;
    public float trailTime;
    public TrailRenderer trailRenderer;
    public float holeRatio;
    public GameObject holePrefab;

    private void Start()
    {
        trailRenderer.time = trailTime;

        GameManager.Instance.TrailUp += IncrementTrail;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TrailUp -= IncrementTrail;
    }

    private void Update()
    {
        if (Time.time % spawnInterval < Time.deltaTime)
        {
            SpawnNode();
        }
    }

    private void SpawnNode()
    {
        GameObject newNode = Instantiate(nodePrefab, nodeSpawner.position, Quaternion.identity);
        trailNodes.Insert(0, newNode);

        TrailNode node = newNode.GetComponent<TrailNode>();
        node.Initialization(this, trailTime);

    }

    public void RemoveNode(GameObject nodeToRemove)
    {
        if (trailNodes.Contains(nodeToRemove))
        {
            trailNodes.Remove(nodeToRemove);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TrailNode")
        {
            int nodeIndex = trailNodes.IndexOf(other.gameObject);

            if (nodeIndex > 3)
            {
                DetectCircle(nodeIndex);
            }
        }
    }

    private void DetectCircle(int lastNodeIndex)
    {
        print(lastNodeIndex);
        int circleSize = lastNodeIndex+1;
        GameObject[] circleNodes = new GameObject[circleSize];

        for (int i = 0; i < circleSize; i++)
        {
            circleNodes[i] = trailNodes[0];
            RemoveNode(circleNodes[i]);
        }

        /////Find center & radius
        float averagedRadius = 0;
        Vector3 averagedCenter = Vector3.zero;
        for (int i = 0; i < circleSize / 2; i++)
        {
            Vector3 diameter = circleNodes[(i + circleSize / 2)% circleSize].transform.position - circleNodes[i].transform.position;
            Vector3 radius = diameter / 2;
            Vector3 centerPoint = circleNodes[i].transform.position + radius;

            averagedRadius += radius.magnitude;
            averagedCenter += centerPoint;
        }

        averagedCenter /= circleSize / 2;
        averagedRadius /= circleSize / 2;

        if (averagedRadius > 1f)
        {
            SpawnHole(averagedCenter, averagedRadius);
        }
    }

    private void SpawnHole(Vector3 spawnPosition, float radius)
    {
        spawnPosition = new Vector3(spawnPosition.x, 0f, spawnPosition.z);
        float scaletoRadius = radius * 2 / holeRatio;

        //GameObject newHole = Instantiate(holePrefab, spawnPosition, Quaternion.identity);
        Vector3 scale = new Vector3(scaletoRadius, scaletoRadius, scaletoRadius);
        PoolManager.instance.CreateObject(Poolables.Hole, spawnPosition, scale);
    }

    private void IncrementTrail(float amount)
    {
        trailTime += amount;
        trailRenderer.time = trailTime;
    }
}
