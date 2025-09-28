using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] CanvasGroup winUI, interactUI, getMoreCoinUI;
    int Target = 1;
    // Start is called before the first frame update


    
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(interact(Target));
            if (other.GetComponent<PlayerController>() != null)
            {
                if (other.GetComponent<PlayerController>().isInteracting)
                {
                    Target = 0;
                    StartCoroutine(interact(Target));
                    if (other.GetComponent<CoinCollector>() != null && other.GetComponent<CoinCollector>().getCoinCount() >= 5)
                    {
                        StartCoroutine(WinGame());
                    }
                    else
                    {
                        StartCoroutine(getMoreCoins());
                    }
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (interactUI.alpha > 0)
            {
                StartCoroutine(interact(Target));
                Target = 1;
            }
            Target= 1;
        }
    }
    IEnumerator WinGame()
    {
        winUI.alpha= Mathf.Lerp(winUI.alpha, 1, 0.5f);
        WaitForSeconds wait = new WaitForSeconds(10);
        SceneManager.LoadScene("Start_Menu");
        yield return null;
    }
    IEnumerator interact(int target)
    {
        interactUI.alpha = Mathf.Lerp(interactUI.alpha, target, 0.5f);
        yield return null;
    }
    IEnumerator getMoreCoins()
    {
        getMoreCoinUI.alpha = Mathf.Lerp(getMoreCoinUI.alpha, 1, 0.1f);
        WaitForSeconds wait = new WaitForSeconds(5);
        getMoreCoinUI.alpha = Mathf.Lerp(getMoreCoinUI.alpha, 0, 0.1f);
        yield return null;
    }
}
