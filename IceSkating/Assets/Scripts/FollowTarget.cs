using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        if (target == null) return; 

        transform.position = target.transform.position + offset;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void StopFollowingTarget()
    {
        target = null;
    }
}
