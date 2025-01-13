using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBoss : MonoBehaviour
{
    // 壁のトリガーに触れたときに呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤータグを持つオブジェクトに触れた場合
        if (other.CompareTag("player"))
        {
            // 別のシーンに移動
            SceneManager.LoadScene("boss"); // シーン名を指定
        }
    }
}
