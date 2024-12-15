using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpUIManager : MonoBehaviour
{
    public TMP_Text powerUpText; // Referència al text de la UI
    private float powerUpEndTime; // Temps quan s'acaba el power-up
    private bool powerUpActive = false; // Indica si un power-up està actiu

    void Start()
    {
        // Comença amb el text ocult.
        powerUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Si hi ha un power-up actiu, actualitza la seva durada
        if (powerUpActive && Time.time > powerUpEndTime)
        {
            powerUpText.gameObject.SetActive(false); // Amaga el text quan acabi
            powerUpActive = false;
        }
    }

    public void DisplayPowerUp(string powerUpName, float duration)
    {
        // Mostra el power-up activat
        powerUpText.text = $"{powerUpName} Active!";

        powerUpText.gameObject.SetActive(true); // Fa visible el text
        powerUpEndTime = Time.time + duration; // Estableix quan ha de desaparèixer
        powerUpActive = true;
    }
}
