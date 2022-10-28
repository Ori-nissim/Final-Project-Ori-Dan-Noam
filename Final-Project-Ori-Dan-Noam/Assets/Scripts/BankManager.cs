using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public GameObject alarms;
    private AudioSource alarmsSound;
    private void Awake()
    {
        alarmsSound = GetComponent<AudioSource>();
        alarms.SetActive(false);
    }
    void Start()
    {
        
        Invoke("startAlarms", 1f);
    }

    // Update is called once per frame

    private void startAlarms()
    {
        alarmsSound.Play();
        alarms.SetActive(true);
    }
    
}
