using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    static float[][] attackWeight = new float[][]
    {
        new float[] { 50, 30 },
        new float[] { 40, 40 },
    };
    private int attackKind;

    public float attackCoolTimeMin;
    public float attackCoolTimeMax;
    public float attackTimer;
    public float attackTime;

    private GameObject attack1_2JudgeObject;
    private Attack1_2Judgement attack1_2JudgeScript;


    public int bossHp;
    public int currentBossHp;
    //private int bossState;

    public GameObject[] enemyPrefab;
    private Animator animator;
    private Rigidbody bossRb;


    // Start is called before the first frame update
    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentBossHp = bossHp;

        //1-2attack
        attack1_2JudgeObject = GameObject.Find("Attack1_2judgeObject");
        attack1_2JudgeScript = attack1_2JudgeObject.GetComponent<Attack1_2Judgement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= attackTimer)
        {
            attackTimer = 0;
            attackTime = Random.Range(attackCoolTimeMin, attackCoolTimeMax);
            attackKind = ChooseAttacKind(attackWeight[BossState()][0], attackWeight[BossState()][1]);
            Attack(BossState(),attackKind);
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
        
        if(currentBossHp==0)
        {
            Debug.Log("KILL");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("cushion"))
        {
            currentBossHp--;
            if (currentBossHp == 10)
            {
                animator.SetTrigger("change");
                attackTimer -= 4;
            }
        }
    }

    private int BossState()
    {
        if (currentBossHp >= 10)
        {
            return 0;
        }
        else if (currentBossHp < 10)
        {
            return 1;
        }
        else
        {
            return 1;
        }
    }

    private int ChooseAttacKind(float a,float b)
    {
        float kind = Random.Range(0, a+b);
        if ( kind <= a )
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    private void Attack(int a,int b)
    {
        switch (a)
        {
            case 0:
                switch (b)
                {
                    case 0:Attack1_1(); break;
                    case 1:Attack1_2(); break;
                    default:return;
                }
                break;
            case 1:
                switch (b)
                {
                    case 0:Attack2_1(); break;
                    case 1:Attack2_2(); break;
                    default:return;
                }break;
            default:return;
        }
    }

    public void Attack1_1()
    {
        int enemyPrefabIndex=Random.Range(0,enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyPrefabIndex], transform.position, enemyPrefab[enemyPrefabIndex].transform.rotation);
        animator.SetTrigger("1o1");
    }

    private void Attack1_2 ()
    {
        //animation
        animator.SetTrigger("1o2");
        Invoke("Attack1_2Judge", 2.50f);
    }
    private void Attack1_2Judge()
    {
        if(attack1_2JudgeScript.Judge()==true)
        {
            //
        }
    }
    private void Attack2_1()
    {
        //animation
        animator.SetTrigger("2o1");
        attackTimer -= 3.0f;
    }
    private void Attack2_2()
    {
        //GameObjectChange
        animator.SetTrigger("2o2");
    }
}
