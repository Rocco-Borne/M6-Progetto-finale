using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Slider healthSlider;
    float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController component not found on the GameObject.");
            return;
        }
        maxHealth = playerController.getHealth();
        healthSlider.maxValue =  maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerController.getHealth();
        healthSlider.value = currentHealth;
    }
}
