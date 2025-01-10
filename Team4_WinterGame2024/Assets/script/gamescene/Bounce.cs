using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 10f; // ���˂��

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g������̏��iBounceFloor�^�O�j���m�F
        if (collision.gameObject.CompareTag("BounceFloor"))
        {
            // Rigidbody�ɏ�����̗͂�������
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // ������̗͂�������
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
