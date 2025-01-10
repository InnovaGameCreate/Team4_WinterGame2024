using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCrumblingFloor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // cushionと衝突したかを判定
        if (collision.gameObject.CompareTag("cushion"))
        {
            Debug.Log("Cushion hit the floor. Floor will be destroyed.");
            Destroy(gameObject); // このスクリプトがアタッチされている床を削除
        }
    }
}
