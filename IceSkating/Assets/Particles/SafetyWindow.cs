using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyWindow : MonoBehaviour
{
    [SerializeField] private Collider holeCollider;
    [SerializeField] private float windowTime;
    bool justSpawned;

    public void Start()
    {
        StartWindow();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hole" && justSpawned)
        {
            Poolable p = other.gameObject.GetComponent<Poolable>();
            PoolManager.instance.DestroyObject(p);
        }
    }

    public void StartWindow()
    {
        Invoke("ActivateCollider", windowTime);
        holeCollider.enabled = false;
        justSpawned = true;
    }

    private void ActivateCollider()
    {
        holeCollider.enabled = true;
        justSpawned = false;
    }

}
