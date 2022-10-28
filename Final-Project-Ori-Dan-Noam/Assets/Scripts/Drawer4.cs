using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class Drawer4 : MonoBehaviour
{
    public GameObject CrossHair;
   // public GameObject CrossHairTouch;
    public GameObject Eye;
    public Text Instruction;
    //public Text Instruction1;
    public Animator animator;
    private AudioSource sound;
    //public GameObject Bomb1;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "Openable")
            {
                Instruction.gameObject.SetActive(true);
            }
            else
            {
                Instruction.gameObject.SetActive(false);
            }

            if (hit.transform.gameObject == this.gameObject)//this.gameObject is Script Object
            {
                CrossHair.SetActive(false);
                // CrossHairTouch.SetActive(true);
                // Instruction.gameObject.SetActive(true);
                //
                //Instruction.gameObject.tag == Openable;
                //
                if (Input.GetKeyDown(KeyCode.O)) //prass " O "
                {
                    animator.SetBool("Open", true);
                    sound.Play();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    animator.SetBool("Open", false);
                    sound.Play();
                }
                /*
                if (Input.GetKeyDown(KeyCode.E)) //prass " E "
                {
                    Bomb1.SetActive(false);
                    
                    sound.Play();
                }*/
            }
            else
            {
                CrossHair.SetActive(true);
                //  CrossHairTouch.SetActive(false);
                //Instruction.gameObject.SetActive(false);
            }
        }
       /* if (hit.transform.gameObject.tag == "Takeable")
        {

           Instruction1.gameObject.SetActive(true);
            //print("BOMB!!!!!!!!!!!!!!!!");
        }
            else
            {
                Instruction1.gameObject.SetActive(false);
            }
         */  
        
    }
}
