using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int score = 0;

    public void AddPoints(int points)
    {
        score += points;
    }
}
