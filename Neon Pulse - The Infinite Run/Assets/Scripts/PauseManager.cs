using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false; // Estat de pausa
    public GameObject pauseMenuUI;      // Men� de pausa (UI Canvas)

    void Start()
    {
        // Amaga el men� de pausa quan comen�a el joc
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
            pauseMenuUI.SetActive(true); // Mostra el men� de pausa
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el temps del joc
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Oculta el men� de pausa
        }
    }

    public void QuitGame()
    {
        Debug.Log("Surt del joc");
        Application.Quit(); // Tanca l'aplicaci�
    }
}
