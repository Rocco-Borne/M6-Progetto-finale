using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinCount;
    public TextMeshProUGUI coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {  
            coinCount += other.GetComponent<Coin>().getValue();
            coinText.text = "Coins Collected: " + coinCount.ToString();
            Debug.Log("Coin collected! Total coins: " + coinCount); //debug apparentemente necessario altrimenti non raccoglieva le monete

            Destroy(other.gameObject);
        }
    }
    public int getCoinCount()
    {
        return coinCount;
    }
}
