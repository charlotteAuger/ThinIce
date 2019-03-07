using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float radius;

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(SetRandomDestination());
        }
    }

    private void Start()
    {
        if (gameObject.activeInHierarchy)
        {
            InitMovement();
        }
    }

    public void InitMovement()
    {
        StartCoroutine(SetRandomDestination());
    }

    private IEnumerator SetRandomDestination()
    {
        yield return null;
        bool correct = false;

        Vector2 randomPoint;
        Vector3 destinationPoint;

        while (!correct)
        {
            randomPoint = Random.insideUnitCircle * radius;
            destinationPoint = new Vector3(randomPoint.x, 0, randomPoint.y);

            agent.SetDestination(destinationPoint);

            while (agent.pathPending)
            {
                yield return null;
            }

            if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                correct = true;
            }
        
        }


    }
}
