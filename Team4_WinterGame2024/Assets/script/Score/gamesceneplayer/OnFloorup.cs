using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloorup : MonoBehaviour
{
    public int scoreValue = 100;
    private bool hasScored = false; // �X�R�A�擾�ς݃t���O

    private void OnCollisionEnter(Collision collision)
    {
        if(!hasScored && collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Debug.Log("Player touched the floor! + " + scoreValue);
            hasScored = true; // �X�R�A�擾�ς݂ɐݒ�
        }
    }
}
