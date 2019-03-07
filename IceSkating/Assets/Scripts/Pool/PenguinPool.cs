using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinPool : Poolable
{
    [SerializeField] private Collider c;
    [SerializeField] private Rigidbody rB;
    [SerializeField] private Animator animator;
    [SerializeField] private AIController controller;
    [SerializeField] private NavMeshAgent agent;

    public override void Spawn()
    {
        base.Spawn();
        c.enabled = true;
        rB.useGravity = false;
        rB.isKinematic = true;
        animator.SetBool("Dead", false);
        controller.enabled = true;
        controller.InitMovement();
        agent.enabled = true;
    }

    public override void Disable()
    {
        base.Disable();
        LevelGenerator.instance.RemoveElement(this);
    }
}
