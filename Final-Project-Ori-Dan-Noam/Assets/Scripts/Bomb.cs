using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Bomb : MonoBehaviour
{
    public GameObject CrossHair;
    // public GameObject CrossHairTouch;
    public GameObject Eye;
    public Text Instruction1;
    // public Animator animator;
    private AudioSource sound;
    private AudioSource sound1;
    public GameObject Bomb1;
    public GameObject Door;
    public GameObject Smoke;
    bool flag1 = true;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit1;
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit1))
        {
            if (hit1.transform.gameObject.tag == "Bombable")
            {
                Instruction1.gameObject.SetActive(true);
            }
            else
            {
                Instruction1.gameObject.SetActive(false);
            }
            if (hit1.transform.gameObject == this.gameObject)//this.gameObject is Script Object
            {
                CrossHair.SetActive(false);
                // CrossHairTouch.SetActive(true);
                // Instruction.gameObject.SetActive(true);
                //
                //Instruction.gameObject.tag == Openable;
                //
                if (Input.GetKeyDown(KeyCode.P)) //prass " O "
                {
                    Bomb1.SetActive(true);
                    //animator.SetBool("Open", true);
                    sound.Play();
                    //if (flag1 == true)//arrived to P01
                    //{
                        print("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Invoke("DoorExplode", 1);



                                           

                    //}

                }
                else
                {
                    CrossHair.SetActive(true);
                    //  CrossHairTouch.SetActive(false);
                    //Instruction.gameObject.SetActive(false);
                }
            }
        }

        
    }
    void DoorExplode()
    {
        Door.SetActive(false);
        Smoke.SetActive(true);
        flag1 = false;
    }
}