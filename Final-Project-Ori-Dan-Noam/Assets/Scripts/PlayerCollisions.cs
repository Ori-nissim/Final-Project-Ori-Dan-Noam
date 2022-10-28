using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private AudioSource moneyPickup;
    public GameManager gameManager;

    private void Awake()
    {
        moneyPickup = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            moneyPickup.Play();
            gameManager.updateMoney(Random.Range(100,1000));
            Destroy(other.gameObject, 0.2f);
        }
        if (other.CompareTag("Gold"))
        {
            moneyPickup.Play();
            gameManager.updateGold(Random.Range(100, 1000));
            Destroy(other.gameObject, 0.2f);
        }
    }
}
