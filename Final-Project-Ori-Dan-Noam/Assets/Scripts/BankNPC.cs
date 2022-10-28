using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BankNPC : MonoBehaviour
{
    private Animator animator;
    public GameManager gameManager;
    public GameObject target;

    private NavMeshAgent navMeshAgent;
    private bool isWaiting = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isWaiting)
        {
            if (gameManager.shotsHasBeenFired)
            {
                animator.Play("Run");
                navMeshAgent.SetDestination(target.transform.position);
                isWaiting = false;

            }
        }
    }
}
