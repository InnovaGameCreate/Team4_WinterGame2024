using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransformを指定する
    public float fixedY = 5f; // 固定したいy座標
    public float minX; // x座標の最小値
    public float maxX; // x座標の最大値

    void Update()
    {
        if (player != null)
        {
            float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
            // カメラの新しい位置を計算（x座標はプレイヤー、y座標は固定、z座標は現在のまま）
            Vector3 newPosition = new Vector3(clampedX, fixedY, transform.position.z);

            // カメラの位置を更新
            transform.position = newPosition;
        }
    }
}
