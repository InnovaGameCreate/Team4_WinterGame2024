using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;

    private float horizontalInput;
    [SerializeField]public float playerspeed;
    private Rigidbody playerRb;
    [SerializeField] public float jumpCoolTime;
    private float jumpCoolTimer;
    [SerializeField]public float jumpPower;


    [SerializeField]public GameObject cushionPrefab;
    [SerializeField] public float damegeCoolTime;
    private float damegeCoolTimer;

    [SerializeField]public float cushionCoolTime;
    private float cushionCoolTimer;
    [SerializeField]public float launchAngle;

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
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Enemy"))
        {
            if (PlayerDamage() == true)
            {
                damegeCoolTimer = 0;
            }
        }
    }
    */
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
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * playerspeed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (Playerjump() == true))
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
            Instantiate(cushionPrefab, transform.position, cushionPrefab.transform.rotation);
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
        if (damegeCoolTimer>=damegeCoolTime)
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