using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinDeathHandler : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIController controller;
    [SerializeField] private Rigidbody rB;
    [SerializeField] private Animator animator;
    //Camera script

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            this.gameObject.layer = LayerMask.NameToLayer("Falling");
            StartCoroutine(DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        rB.useGravity = true;
        rB.isKinematic = false;
        agent.enabled = false;
        controller.enabled = false;
        animator.SetBool("Dead", true);
    }
}
