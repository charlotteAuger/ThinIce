using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyWindow : MonoBehaviour
{
    [SerializeField] private Collider holeCollider;
    [SerializeField] private float windowTime;

    private void Start()
    {
        Invoke("ActivateCollider", windowTime);
    }

    private void ActivateCollider()
    {
        holeCollider.enabled = true;
    }

}
