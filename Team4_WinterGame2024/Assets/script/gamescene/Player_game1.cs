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
    private bool hasRotatedPositive = false; // 正方向で回転したかどうか
    private bool hasRotatedNegative = true; // 負方向で回転したかどうか
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

    //衝突した相手が「Enemy」タグを持つ場合、ダメージ処理
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

        // 正方向を向いていてAキーが押された場合
        if (xAxisDirection > 0 && !hasRotatedPositive && Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f); // y軸で180度回転
            hasRotatedPositive = true;
            hasRotatedNegative = false;
        }
        // 負方向を向いていてDキーが押された場合
        else if (xAxisDirection < 0 && !hasRotatedNegative && Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 180f, 0f); // y軸で180度回転
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
            
            // クッションを生成
            GameObject cushion = Instantiate(cushionPrefab, transform.position, cushionPrefab.transform.rotation);
            float d = 0f;
            // Rigidbodyを取得してX軸方向に力を加える
            Rigidbody cushionRb = cushion.GetComponent<Rigidbody>();
            if (cushionRb != null)
            {
                // X軸方向に指定の角度で力を加える
                if (hasRotatedNegative == true)
                {
                    d = 0f;
                    cushionRb.AddForce(new Vector3(d, 0, 0), ForceMode.Impulse); // 正方向に力を加える
                }
                else if (hasRotatedPositive == true)
                {
                    d = -20f;
                    cushionRb.AddForce(new Vector3(d, 0, 0), ForceMode.Impulse); // 負方向に力を加える
                }
            }

            // 投げるアニメーションを再生
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