using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloorup : MonoBehaviour
{
    public int scoreValue = 100;
    private bool hasScored = false; // スコア取得済みフラグ

    private void OnCollisionEnter(Collision collision)
    {
        if(!hasScored && collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Debug.Log("Player touched the floor! + " + scoreValue);
            hasScored = true; // スコア取得済みに設定
        }
    }
}
