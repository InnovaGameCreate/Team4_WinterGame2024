using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    static float[][] attackWeight = new float[][] {
        new float[] { 40, 60 },
        new float[] { 40, 40 },
    };

    private int attackKind;

    public float attackCoolTimeMin;
    public float attackCoolTimeMax;
    public float attackTimer;
    public float attackTime;

    public GameObject attack1_2JudgementObject;
    public Attack1_2Judgement attack1_2JudgementScript;

    public int bossHp;
    public int currentBossHp;

    public GameObject[] enemyPrefab;
    private Animator animator;
    private Rigidbody bossRb;

    private int cushionHitCount = 0;

    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentBossHp = bossHp;

        attack1_2JudgementObject = GameObject.Find("Attack1_2judgeObject");
        attack1_2JudgementScript = attack1_2JudgementObject.GetComponent<Attack1_2Judgement>();
    }

    void Update()
    {
        if (attackTime <= attackTimer)
        {
            attackTimer = 0;
            attackTime = Random.Range(attackCoolTimeMin, attackCoolTimeMax);
            attackKind = ChooseAttacKind(attackWeight[BossState()][0], attackWeight[BossState()][1]);
            Attack(BossState(), attackKind);
        }
        else
        {
            attackTimer += Time.deltaTime;
        }

        if (currentBossHp == 0)
        {
            Debug.Log("KILL");

            // スコアを1500増加
            IncreaseScore(1500);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cushion"))
        {
            currentBossHp--;
            cushionHitCount++;
            Debug.Log("Cushion hit count: " + cushionHitCount);

            if (cushionHitCount >= 10)
            {
                Debug.Log("Cushion hit 10 times, destroying boss object.");

                // スコアを1500増加
                IncreaseScore(1500);

                Destroy(this.gameObject);
            }

            if (currentBossHp == 10)
            {
                animator.SetTrigger("change");
                attackTimer -= 4;
            }
        }
    }

    private int BossState()
    {
        return 0;
    }

    private int ChooseAttacKind(float a, float b)
    {
        float kind = Random.Range(0, a + b);
        if (kind <= a)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    private void Attack(int a, int b)
    {
        switch (a)
        {
            case 0:
                switch (b)
                {
                    case 0: Attack1_1(); break;
                    case 1: Attack1_2(); break;
                    default: return;
                }
                break;
            case 1:
                switch (b)
                {
                    case 0: Attack2_1(); break;
                    case 1: Attack2_2(); break;
                    default: return;
                }
                break;
            default: return;
        }
    }

    public void Attack1_1()
    {
        int enemyPrefabIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyPrefabIndex], transform.position, enemyPrefab[enemyPrefabIndex].transform.rotation);
        animator.SetTrigger("1o1");
    }

    private void Attack1_2()
    {
        animator.SetTrigger("1o2");
        Invoke("Attack1_2Judge", 3.0f);
    }

    private void Attack1_2Judge()
    {
        attack1_2JudgementScript.Judge();
    }

    private void Attack2_1()
    {
        animator.SetTrigger("2o1");
        attackTimer -= 3.0f;
    }

    private void Attack2_2()
    {
        animator.SetTrigger("2o2");
    }

    // スコアを増加させる共通メソッド
    private void IncreaseScore(int amount)
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.score += amount;
            ScoreManager.Instance.UpdateScoreDisplay();
            Debug.Log("Score increased by " + amount + "!");
        }
        else
        {
            Debug.LogError("ScoreManager.Instance is null! Cannot increase score.");
        }
    }
}
