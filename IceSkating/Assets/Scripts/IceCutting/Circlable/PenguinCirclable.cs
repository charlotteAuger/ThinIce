using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinCirclable : Circlable
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIController controller;


    public override void Swallowed()
    {
        base.Swallowed();

        agent.Stop();
        Destroy(agent);
        Destroy(controller);
    }
}
