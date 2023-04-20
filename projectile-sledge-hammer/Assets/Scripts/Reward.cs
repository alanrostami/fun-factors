using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public Text ScoreText;
    public static int score;
    public int maxScore;

    void Start()
    {
        score = 0;    
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    void Update()
    {
        UpdateScore();
    }
}
