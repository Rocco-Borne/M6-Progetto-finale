using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] CanvasGroup winUI, interactUi;
    int Target = 1;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine(interact(Target));
            Target = 0;
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null && other.GetComponent<PlayerController>().isInteracting)
        {
            StartCoroutine(WinGame());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(interact(Target));
        }
    }
    IEnumerator WinGame()
    {
        winUI.alpha= Mathf.Lerp(winUI.alpha, 1, 0.5f);
        WaitForSeconds wait = new WaitForSeconds(10);
        SceneManager.LoadScene("Start_Menu");
        yield return null;
    }
    IEnumerator interact(int Target)
    {
        interactUi.alpha = Mathf.Lerp(interactUi.alpha, Target, 0.5f);
        yield return null;
    }
}
