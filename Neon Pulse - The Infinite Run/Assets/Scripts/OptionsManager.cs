using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider difficultySlider; // Slider per canviar la dificultat
    public Text difficultyText;     // Text per mostrar la dificultat seleccionada

    public void ChangeDifficulty()
    {
        // Obtenim el valor del Slider per la dificultat
        float difficultyValue = difficultySlider.value;
        difficultyText.text = "Dificultat: " + difficultyValue.ToString("0.00");

        // Actualitzem la dificultat a DifficultyManager
        /**if (DifficultyManager.instance != null)
        {
            DifficultyManager.instance.SetDifficulty(difficultyValue);
        }
        else
        {
            Debug.LogError("DifficultyManager instance no trobat!");
        }*/
    }

    public void GoBackToMainMenu()
    {
        // Torna al menú principal
        SceneManager.LoadScene("MainMenu");
    }
}
