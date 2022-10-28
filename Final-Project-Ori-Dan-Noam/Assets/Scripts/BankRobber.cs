using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BankRobber : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public GameObject player;
    public GameObject target;

    public GameObject exitPoint;
    public GameObject projectile;
    public GameObject muzzleFlash;

    public float velocity;
    public float timeBetweenShots = 2f;
    private bool isReady = true;
    private AudioSource shootingSound;


    float distance;
    private bool isEnemyInRange = false;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        shootingSound = GetComponent<AudioSource>();
        muzzleFlash.SetActive(false);
        target = player;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Agent")
        {
            isEnemyInRange = true;
            target = other.gameObject;
            animator.Play("Shooting");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agent")
        {
            isEnemyInRange = false;
            target = player;

        }
    }

    void Update()
    {
        if (target == null)
            target = player;

        if (!isEnemyInRange)
        {
            navMeshAgent.SetDestination(player.transform.position);
            checkDistanceFromTarget();
           
            navMeshAgent.speed = 3f;
        }
        else
        {
            if (isReady)
                StartCoroutine("shootWeapon");  
            

            navMeshAgent.speed = 0.5f;

        }
        lookOn(target);

        if (Input.GetKey(KeyCode.X))
        {
            isEnemyInRange = false;
            target = player;
        }
        /*if (Input.GetKey(KeyCode.C))
        {
            isEnemyInRange = true;
            target = player;
        }*/
    }

    IEnumerator shootWeapon() // create a projectile and fire it
    {
        isReady = false;

        StartCoroutine("showMuzzleFlash");
        shootingSound.Play();
        GameObject bullet = Instantiate(projectile, exitPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity, ForceMode.Impulse
            );

        yield return new WaitForSeconds(timeBetweenShots);

        isReady = true;
    }

    IEnumerator showMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        muzzleFlash.SetActive(false);
    }


    private void checkDistanceFromTarget()
    {
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance < 4.7f)
        {
            animator.CrossFade("Rifle Idle", 0.2f);
        }
        else
        {
            animator.Play("Walk Rifle");
        }
    }

    private void lookOn(GameObject targetObject)  
    {
        Vector3 direction = targetObject.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        direction.x = 0;
        transform.rotation = rotation;
    }



}
