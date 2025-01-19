using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class Player_game1 : MonoBehaviour
{
    private Animator animator;


    private float horizontalInput;
    [SerializeField] public float playerspeed;
    private Rigidbody playerRb;
    [SerializeField] public float jumpCoolTime;
    private float jumpCoolTimer;
    [SerializeField] public float jumpPower;


    [SerializeField] public GameObject cushionPrefab;
    [SerializeField] public float damegeCoolTime;
    private float damegeCoolTimer;

    [SerializeField] public float cushionCoolTime;
    private float cushionCoolTimer;
    [SerializeField] public float launchAngle;
    private bool hasRotatedPositive = false; // �������ŉ�]�������ǂ���
    private bool hasRotatedNegative = true; // �������ŉ�]�������ǂ���
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Cushion();
        Damage();
        Rotate();
    }

    //�Փ˂������肪�uEnemy�v�^�O�����ꍇ�A�_���[�W����
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (PlayerDamage() == true)
            {
                damegeCoolTimer = 0;
            }
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            animator.SetBool("walk", true);
        }
        else if (horizontalInput == 0)
        {
            animator.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, horizontalInput) * playerspeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, -1 * horizontalInput) * playerspeed * Time.deltaTime);
        }

    }

    private void Rotate()
    {
        float xAxisDirection = transform.forward.x;

        // �������������Ă���A�L�[�������ꂽ�ꍇ
        if (xAxisDirection > 0 && !hasRotatedPositive && Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f); // y����180�x��]
            hasRotatedPositive = true;
            hasRotatedNegative = false;
        }
        // �������������Ă���D�L�[�������ꂽ�ꍇ
        else if (xAxisDirection < 0 && !hasRotatedNegative && Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 180f, 0f); // y����180�x��]
            hasRotatedNegative = true;
            hasRotatedPositive = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && (Playerjump() == true) && Mathf.Abs(playerRb.velocity.y) < 0.01f)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            animator.SetTrigger("jump");
            jumpCoolTimer = 0;
        }

        if (jumpCoolTimer < jumpCoolTime)
        {
            jumpCoolTimer += Time.deltaTime;
        }
    }

    private void Cushion()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (LaunchCushion() == true))
        {
            
            // �N�b�V�����𐶐�
            GameObject cushion = Instantiate(cushionPrefab, transform.position, cushionPrefab.transform.rotation);
            float d = 0f;
            // Rigidbody���擾����X�������ɗ͂�������
            Rigidbody cushionRb = cushion.GetComponent<Rigidbody>();
            if (cushionRb != null)
            {
                // X�������Ɏw��̊p�x�ŗ͂�������
                if (hasRotatedNegative == true)
                {
                    d = 0f;
                    cushionRb.AddForce(new Vector3(d, 0, 0), ForceMode.Impulse); // �������ɗ͂�������
                }
                else if (hasRotatedPositive == true)
                {
                    d = -20f;
                    cushionRb.AddForce(new Vector3(d, 0, 0), ForceMode.Impulse); // �������ɗ͂�������
                }
            }

            // ������A�j���[�V�������Đ�
            animator.SetTrigger("throw");
            cushionCoolTimer = 0;
        }

        if (cushionCoolTimer < cushionCoolTime)
        {
            cushionCoolTimer += Time.deltaTime;
        }
    }

    private void Damage()
    {
        if (damegeCoolTimer < damegeCoolTime)
        {
            damegeCoolTimer += Time.deltaTime;
        }
    }

    public bool PlayerDamage()
    {
        if (damegeCoolTimer >= damegeCoolTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Playerjump()
    {
        if (jumpCoolTimer >= jumpCoolTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LaunchCushion()
    {
        if (cushionCoolTimer >= cushionCoolTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}