using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton per accedir al GameManager des de qualsevol script

    public Text coinText; // Text UI per mostrar el nombre de monedes recollides
    private int totalCoins = 0; // Total de monedes recollides pel jugador

    private void Awake()
    {
        // Configuració del Singleton per assegurar que només hi ha un GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantenim el GameManager entre escenes
        }
        else
        {
            Destroy(gameObject); // Destruïm instàncies addicionals del GameManager
        }
    }

    public void AddCoin(int amount)
    {
        // Incrementa el total de monedes i actualitza el text de la UI
        totalCoins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        // Actualitza el text amb el nombre de monedes
        if (coinText != null)
        {
            coinText.text = "Monedes: " + totalCoins.ToString();
        }
    }
}
