using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Poolables { Flag, Penguin, Hole };

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    public Poolable[] holes;
    public Poolable[] flags;
    public Poolable[] penguins;

    private void Awake()
    {
        if (instance == null) instance = this;

        else Destroy(this);
    }

    public Poolable CreateObject(Poolables type, Vector3 position, Vector3 scale)
    {
        //Check pool for available bullet
        Poolable result = null;

        Poolable[] pool = null;

        switch (type)
        {
           case Poolables.Flag :
                pool = flags;
                break;

            case Poolables.Hole:
                pool = holes;
                break;

            case Poolables.Penguin:
                pool = penguins;
                break;
        }

        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].isAvailable)
            {
                result = pool[i];
                break;
            }
        }

        result.Spawn();
        result.transform.position = position;
        result.transform.localScale = scale;

        return result;
    }

    public void DestroyObject(Poolable pToDestroy)
    {
        pToDestroy.Disable(); 
    }
}
