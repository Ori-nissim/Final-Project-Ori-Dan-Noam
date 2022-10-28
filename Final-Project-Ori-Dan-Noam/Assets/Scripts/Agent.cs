using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject target;
    public GameObject exitPoint;
    public GameObject projectile;
    public GameObject muzzleFlash;
    public BankRobber bankRobber;
    public BankRobber bankRobber2;
    public float velocity;
    public float timeBetweenShots = 2f;
    private Animator animator;
    private float distance;
    private bool isReady = true;
    private AudioSource shootingSound;

    private float health = 20f;
    private bool isAlive = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        shootingSound = GetComponent<AudioSource>();
        muzzleFlash.SetActive(false);

    }
    void Update()
    {

       
       if (isAlive)
        checkDistanceFromTarget();
        
    }

    private void checkDistanceFromTarget()
    {
        distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        
        if (distance < 20f)
        {
            animator.CrossFade("Firing",0.3f);
            lookOnTarget();
            if(isReady)
                StartCoroutine("shootWeapon");
        }
        else
        {
            animator.CrossFade("Idle", 0.3f);
        }
    }

    private void lookOnTarget()  // make the agent and the gun exit point to look at the target
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = rotation;
    }

    IEnumerator shootWeapon() // create a projectile and fire it
    {
        isReady = false;

        StartCoroutine("showMuzzleFlash");
        shootingSound.Play();
        GameObject bullet = Instantiate(projectile, exitPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * velocity , ForceMode.Impulse
            );

        yield return new WaitForSeconds(timeBetweenShots);

        isReady = true;
    }

    IEnumerator showMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        muzzleFlash.SetActive(false);
    }

    public void takeDamage(float damage)
    {
        Debug.Log("Took damage, health:" + health);
        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            animator.Play("FallAndDie");
            bankRobber.target = target;
            bankRobber2.target = target;
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RobberBullet")
        {
            takeDamage(10);
            print("Took damage from crew mate");
        }
    }
}
