using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Anubis : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Eye;
    public Text Instruction1;// text will be " press E to break the glass" 
    //public Text Instruction2;//"press T to take the anubis"
    public GameObject Glass;
    public GameObject BrokenGlass;
    public GameObject anubis;
    public bool flag = true;
    public bool flag1 = true;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        //BrokenGlass.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit))
        {
            //print(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Anubis")
            {
                print("hit!!");
                if(flag1==true)
                    Instruction1.gameObject.SetActive(true);
               // Glass.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)&&flag==true) //press " E "
                {

                    BrokenGlass.gameObject.SetActive(true);
                    Glass.gameObject.SetActive(false);
                    sound.Play();//broken glass sound
                    flag = false;
                    flag1 = false;

                }
            }
            else
            {
                Instruction1.gameObject.SetActive(false);
            }
           /* Instruction2.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T) ) //press " T "
            {

                anubis.gameObject.SetActive(false);
                
                
                //flag = false;
                //flag1 = false;

            }
            else
            {
                Instruction2.gameObject.SetActive(false);
            }*/
        }
    }


}

