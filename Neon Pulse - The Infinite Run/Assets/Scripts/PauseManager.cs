using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Reinicia el joc amb la tecla "R"
        if (isPaused && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
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
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reanuda el temps abans de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega l'escena actual
    }

    public void QuitGame()
    {
        Debug.Log("Surt del joc");
        Application.Quit(); // Tanca l'aplicaci�
    }
}
