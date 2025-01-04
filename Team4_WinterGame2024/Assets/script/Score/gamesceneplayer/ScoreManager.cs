using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score;
    public Text scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Current Score" + score);
    }

    internal void DecreaseScore(int scoreValue)
    {
        score -= scoreValue;
        Debug.Log("Current Score" + score);
    }
    private void UpdateScoreText()
    {
        // ƒXƒRƒA‚ð‰æ–Ê‚É”½‰f‚·‚é
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
