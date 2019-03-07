using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPool : MonoBehaviour
{
    List<Poolable> spawnedStuff = new List<Poolable>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnedStuff.Add(PoolManager.instance.CreateObject(Poolables.Penguin, Vector3.zero, Vector3.one));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            spawnedStuff.Add(PoolManager.instance.CreateObject(Poolables.Hole, Vector3.zero, Vector3.one));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnedStuff.Add(PoolManager.instance.CreateObject(Poolables.Flag, Vector3.zero, Vector3.one));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PoolManager.instance.DestroyObject(spawnedStuff[0]);
            spawnedStuff.RemoveAt(0);
        }


    }
}
