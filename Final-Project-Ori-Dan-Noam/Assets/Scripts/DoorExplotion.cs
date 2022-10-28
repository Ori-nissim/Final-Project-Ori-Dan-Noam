using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExplotion : MonoBehaviour
{
    Animator animator;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        
    }
    void update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //prass " P "
        {
            animator.SetBool("Start", true);
            //sound.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Start", true);
        sound.PlayDelayed(0.6f);
    }

   /* private void OnTriggerExit(Collider other)
    {
        animator.SetBool("IsOpening", false);
        sound.PlayDelayed(0.6f);
    }*/
    // Update is called once per frame
   
}
