using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkatingMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rB;
    private Quaternion currentRotation;
    private Quaternion targetRotation;
    [SerializeField] private CharacterStats stats;
    private bool moving;

    private void Start()
    {
        currentRotation = targetRotation = transform.rotation;
        moving = true;
    }

    public void StopMovement()
    {
        rB.velocity = Vector3.zero;
        moving = false;
    }

    private void FixedUpdate()
    {
        if (!moving) return;

        UpdateVelocity();
        UpdateRotation();
    }

    private void UpdateVelocity()
    {
        rB.velocity = transform.forward * stats.speed;
    }

    public void SetTargetRotation(Vector2 touchDirection)
    {
        Vector3 targetDirection = new Vector3(touchDirection.x, 0, touchDirection.y);
        targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
    }

    //Update current direction to make it closer to the target rotation
    private void UpdateRotation()
    {
        currentRotation = Quaternion.Slerp(currentRotation, targetRotation, stats.rotationSpeed);
        transform.rotation = currentRotation;
    }
}
