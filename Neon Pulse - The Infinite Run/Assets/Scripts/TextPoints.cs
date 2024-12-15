using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPoints : MonoBehaviour
{
    public TMP_Text text;

    private int currentPoints = -1; // Valor inicial diferent de qualsevol puntuaci� possible

    void Start()
    {
        // Inicialitza el text amb la puntuaci� actual
        UpdatePointsText(ScoreManager.instance.GetPoints());
    }

    void Update()
    {
        // Nom�s actualitza el text si la puntuaci� ha canviat
        int newPoints = ScoreManager.instance.GetPoints();
        if (newPoints != currentPoints)
        {
            UpdatePointsText(newPoints);
        }
    }

    private void UpdatePointsText(int points)
    {
        currentPoints = points;
        text.text = $"{points}"; 
    }
}
