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

    private List<Poolable> levelElements = new List<Poolable>();

    public void GenerateLevel(LevelData data)
    {
        //Generation
    }

    public void AddElement(Poolable element)
    {
        levelElements.Add(element);
    }

    public void RemoveElement(Poolable element)
    {
        if (levelElements.Contains(element))
        {
            levelElements.Remove(element);
        }
    }

    public void ClearLevel()
    {
        foreach (Poolable element in levelElements)
        {
            PoolManager.instance.DestroyObject(element);
        }
        levelElements.Clear();
    }
}
