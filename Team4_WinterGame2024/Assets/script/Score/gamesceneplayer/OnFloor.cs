using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OnFloor : MonoBehaviour
{
    public int scoreValue = 100;
    public bool isScoreUp; // true: �X�R�A�A�b�v, false: �X�R�A�_�E��
    private bool hasScored = false; // �X�R�A�擾�ς݃t���O

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player collided with floor: {gameObject.name}");
            hasScored = true;

            // �X�R�A�𒼐ڕύX
            if (isScoreUp)
            {
                ScoreManager.Instance.score += scoreValue;  // �X�R�A�A�b�v
                Debug.Log($"Score Up! +{scoreValue} (Floor: {gameObject.name})");
            }
            else
            {
                ScoreManager.Instance.score -= scoreValue;  // �X�R�A�_�E��
                Debug.Log($"Score Down! -{scoreValue} (Floor: {gameObject.name})");
            }
            ScoreManager.Instance.UpdateScoreDisplay();
        }
    }
}
