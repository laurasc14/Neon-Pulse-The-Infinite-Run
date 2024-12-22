using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource audioSource; // Assigna l'AudioSource al menú

    void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if (audioSource != null)
            audioSource.Play(); // Comença la música del menú principal
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if (isPaused && Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        if (audioSource != null)
            audioSource.Pause(); // Pausa la música
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if (audioSource != null)
            audioSource.UnPause(); // Reprèn la música
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Surt del joc");
        Application.Quit();
    }
}
