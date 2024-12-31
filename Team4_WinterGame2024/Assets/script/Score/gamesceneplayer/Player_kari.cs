using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_kari : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f; // 移動速度
    private float jumpforce = 15f; // ジャンプの力

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity; // 現在の速度を取得

        // 左右移動
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed; // 右方向に一定の速度
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed; // 左方向に一定の速度
        }
        else
        {
            velocity.x = 0; // キー入力がない場合は停止
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.01f) // 地面にいる場合のみジャンプ
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        rb.velocity = velocity; // 修正した速度を適用
    }
}
