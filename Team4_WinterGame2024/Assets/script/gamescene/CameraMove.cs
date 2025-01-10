using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform���w�肷��
    public float fixedY = 5f; // �Œ肵����y���W
    public float minX; // x���W�̍ŏ��l
    public float maxX; // x���W�̍ő�l

    void Update()
    {
        if (player != null)
        {
            float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
            // �J�����̐V�����ʒu���v�Z�ix���W�̓v���C���[�Ay���W�͌Œ�Az���W�͌��݂̂܂܁j
            Vector3 newPosition = new Vector3(clampedX, fixedY, transform.position.z);

            // �J�����̈ʒu���X�V
            transform.position = newPosition;
        }
    }
}
