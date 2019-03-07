using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinCirclable : Circlable
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIController controller;
    [SerializeField] private Animator animator;


    public override void Swallowed()
    {
        base.Swallowed();

        print("penguin ploof");

        agent.Stop();
        agent.enabled = false;
        controller.enabled = false;
        animator.SetBool("Dead", true);
    }
}
