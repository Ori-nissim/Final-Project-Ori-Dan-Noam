using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private AudioSource coinPickup;
    private void Awake()
    {
        coinPickup = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        coinPickup.Play();
    }
}
