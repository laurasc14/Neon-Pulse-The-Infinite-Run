using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false; // Estat de pausa
    public GameObject pauseMenuUI;      // Menú de pausa (UI Canvas)

    void Start()
    {
        // Amaga el menú de pausa quan comença el joc
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el temps del joc
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Mostra el menú de pausa
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el temps del joc
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        }
    }

    public void QuitGame()
    {
        Debug.Log("Surt del joc");
        Application.Quit(); // Tanca l'aplicació
    }
}
