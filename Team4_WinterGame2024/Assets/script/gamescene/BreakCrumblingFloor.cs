using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCrumblingFloor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // cushion�ƏՓ˂������𔻒�
        if (collision.gameObject.CompareTag("cushion"))
        {
            Debug.Log("Cushion hit the floor. Floor will be destroyed.");
            Destroy(gameObject); // ���̃X�N���v�g���A�^�b�`����Ă��鏰���폜
        }
    }
}
