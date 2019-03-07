using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyWindow : MonoBehaviour
{
    [SerializeField] private Collider holeCollider;
    [SerializeField] private float windowTime;

    public void Start()
    {
        StartWindow();
    }

    public void StartWindow()
    {
        Invoke("ActivateCollider", windowTime);
        holeCollider.enabled = false;
    }

    private void ActivateCollider()
    {
        holeCollider.enabled = true;
    }

}
