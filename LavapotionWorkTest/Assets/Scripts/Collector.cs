using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText = null;
    void Awake()
    {
        if(scoreText != null) scoreText.text = score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        if(scoreText != null) scoreText.text = score.ToString();
    }
}
