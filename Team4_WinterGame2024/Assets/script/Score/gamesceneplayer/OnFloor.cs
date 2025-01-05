using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OnFloor : MonoBehaviour
{
    public int scoreValue = 100;
    public bool isScoreUp; // true: スコアアップ, false: スコアダウン
    private bool hasScored = false; // スコア取得済みフラグ

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player collided with floor: {gameObject.name}");
            hasScored = true;

            // スコアを直接変更
            if (isScoreUp)
            {
                ScoreManager.Instance.score += scoreValue;  // スコアアップ
                Debug.Log($"Score Up! +{scoreValue} (Floor: {gameObject.name})");
            }
            else
            {
                ScoreManager.Instance.score -= scoreValue;  // スコアダウン
                Debug.Log($"Score Down! -{scoreValue} (Floor: {gameObject.name})");
            }
            ScoreManager.Instance.UpdateScoreDisplay();
        }
    }
}
