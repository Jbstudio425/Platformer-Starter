using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private Text scoreText = null;
    
    void Awake()
    {
        if(scoreText != null) scoreText.text = points.ToString();
    }

    public void AddPoints(int points)
    {
        this.points += points;
        if(scoreText != null) scoreText.text = this.points.ToString();
    }

    public int GetPoints()
    {
        return points;
    }
}
