using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PortalToBank : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject Eye;
    public Text Instruction;// text will be " press E to enter" 
   /* private void OnTriggerEnter(Collider other)
    {
        int nextScenIndex = SceneManager.GetActiveScene().buildIndex;

        nextScenIndex = 1 - nextScenIndex;//
        StartCoroutine(StartSceneTransition(nextScenIndex));//start parallel execution of function 


    }*/
    void Update()
    {
        int nextScenIndex = SceneManager.GetActiveScene().buildIndex;

        nextScenIndex = 1 - nextScenIndex;//



        RaycastHit hit;
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "Enterable")
            {
                Instruction.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) //press " E "
                {
                    //StartCoroutine(StartSceneTransition(nextScenIndex));//start parallel execution of function 
                    gameManager.firstSceneTransition();
                }
            }
            else
            {
                Instruction.gameObject.SetActive(false);
            }
        }
    }
    

    IEnumerator StartSceneTransition(int sceneIndex)
    {
        /*
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GlobalManager.gold = CoinMotion.numCoins;//save coints to global object
        }

        animator.SetTrigger("StartFadeIn");
        */
        yield return new WaitForSeconds(0.8f);//delay of 3 seconds
        SceneManager.LoadScene(sceneIndex);//index of scene 2
    }
}

