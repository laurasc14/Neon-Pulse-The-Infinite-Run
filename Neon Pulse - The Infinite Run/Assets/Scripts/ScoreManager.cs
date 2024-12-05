using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int points = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void AddPoints(int extrapoints)
    {
        points += extrapoints;
    }

    public int GetPoints()
    {
        return points;
    }
}
