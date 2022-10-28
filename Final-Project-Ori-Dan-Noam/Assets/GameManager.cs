using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gold;
    public TextMeshProUGUI money;

    public GameObject blackScreen;
    private Animator blackScreenAnimator;

    private int moneyCount = 0;
    private int goldCount = 0;

    public bool shotsHasBeenFired = false; // to signal bank NPC to run

    public static GameManager Instance;

    void Awake()
    {
        blackScreenAnimator = blackScreen.GetComponent<Animator>();

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void updateGold(int amount)
    {
        goldCount += amount;
       // money.SetText(goldCount + "");
        gold.SetText(goldCount + "");
    }

    public void updateMoney(int amount)
    {
        moneyCount += amount;
        money.SetText(moneyCount + "");
    }

    public void firstSceneTransition()
    {
        int nextScenIndex = SceneManager.GetActiveScene().buildIndex;

        nextScenIndex = 1 - nextScenIndex;

        GameManager.Instance.moneyCount = moneyCount;

        blackScreenAnimator.Play("Fade");
        StartCoroutine(StartSceneTransition(nextScenIndex));//start parallel execution of function 
        Invoke("shotsFired", 1f);
    }

    IEnumerator StartSceneTransition(int sceneIndex)
    {
        
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Bank");//index of scene 2
    }

    private void shotsFired()
    {
        shotsHasBeenFired = true;
    }
}
