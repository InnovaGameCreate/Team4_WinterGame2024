using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToEnd : MonoBehaviour
{
    [SerializeField] private int badScoreThreshold = 2000;    
    [SerializeField] private int normalScoreThreshold = 4000; 
    [SerializeField] private int goodScoreThreshold = 6000;   

    [SerializeField] private string badScene = "bad";         
    [SerializeField] private string normalScene = "normal";   
    [SerializeField] private string goodScene = "good";       
    [SerializeField] private string completeScene = "complete";

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) 
        {
            if (ScoreManager.Instance != null) 
            {
                int currentScore = ScoreManager.Instance.score;

                
                if (currentScore < badScoreThreshold)
                {
                    SceneManager.LoadScene(badScene); 
                }
                else if (currentScore < normalScoreThreshold)
                {
                    SceneManager.LoadScene(normalScene); 
                }
                else if (currentScore < goodScoreThreshold)
                {
                    SceneManager.LoadScene(goodScene);
                }
                else
                {
                    SceneManager.LoadScene(completeScene); 
                }
            }
            else
            {
                Debug.LogError("ScoreManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñI");
            }
        }
    }
}
