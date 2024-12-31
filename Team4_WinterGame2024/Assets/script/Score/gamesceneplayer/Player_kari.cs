using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_kari : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f; // �ړ����x
    private float jumpforce = 15f; // �W�����v�̗�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity; // ���݂̑��x���擾

        // ���E�ړ�
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed; // �E�����Ɉ��̑��x
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed; // �������Ɉ��̑��x
        }
        else
        {
            velocity.x = 0; // �L�[���͂��Ȃ��ꍇ�͒�~
        }

        // �W�����v
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.01f) // �n�ʂɂ���ꍇ�̂݃W�����v
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        rb.velocity = velocity; // �C���������x��K�p
    }
}
