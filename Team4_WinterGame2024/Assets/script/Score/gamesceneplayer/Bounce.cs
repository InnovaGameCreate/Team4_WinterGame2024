using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 10f; // 跳ねる力

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが特定の床（BounceFloorタグ）か確認
        if (collision.gameObject.CompareTag("BounceFloor"))
        {
            // Rigidbodyに上向きの力を加える
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 上方向の力を加える
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
