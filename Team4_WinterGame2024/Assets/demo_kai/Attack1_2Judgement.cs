using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_2Judgement : MonoBehaviour
{
    private bool hit;

    // ScoreManagerのインスタンスを直接操作するためにインスタンス変数を追加
    private ScoreManager scoreManager;

    void Start()
    {
        hit = false;

        // ScoreManagerインスタンスを直接取得
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    void Update()
    {
        // hit状態が変わった際に即座にスコア変更したい場合
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("player"))
        {
            hit = true;
        }
        else
        {
            hit = false;
        }
    }

    public void Judge()
    {
            Debug.Log("Damage dealt to player!");
        if (hit == true)
        {

            if (scoreManager != null)
            {
                // スコアを減少させる
                scoreManager.score -= 400;
                scoreManager.UpdateScoreDisplay();  // スコア表示を更新
            }
            else
            {
                Debug.LogError("ScoreManager is null! Cannot reduce score.");
            }
        }
    }
}
