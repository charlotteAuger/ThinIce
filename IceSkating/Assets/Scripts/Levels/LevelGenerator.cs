using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    private List<GameObject> levelElements;

    public void GenerateLevel(LevelData data)
    {
        //Generation
    }

    public void AddElement(GameObject element)
    {
        levelElements.Add(element);
    }

    public void ClearLevel()
    {
        levelElements.RemoveAll(item => item == null);
        foreach (GameObject element in levelElements)
        {
            Destroy(element);
        }
        levelElements.Clear();
    }
}
