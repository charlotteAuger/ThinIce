using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
