using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
<<<<<<< Updated upstream:Team4_WinterGame2024/Assets/script/Score/ScoreManager.cs
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
    public int score=0;
    public Text scoreText;
>>>>>>> Stashed changes:Team4_WinterGame2024/Assets/script/Score/gamesceneplayer/ScoreManager.cs

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
        UpdateScoreDisplay();
    }
    public void UpdateScoreDisplay()
    {
<<<<<<< Updated upstream:Team4_WinterGame2024/Assets/script/Score/ScoreManager.cs
        score += value;
        Debug.Log("Current Score" + score);
=======
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
>>>>>>> Stashed changes:Team4_WinterGame2024/Assets/script/Score/gamesceneplayer/ScoreManager.cs
    }
}
