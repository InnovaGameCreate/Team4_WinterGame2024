using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Score : MonoBehaviour
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

    public int bossHp;
    public int currentBossHp;
    //private int bossState;

    public GameObject[] enemyPrefab;
    private Animator animator;
    private Rigidbody bossRb;

    [SerializeField] public string nextScene;


    // Start is called before the first frame update
    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentBossHp = bossHp;
    }

    // Update is called once per frame
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
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Attack1_1();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack1_2();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack2_1();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Attack2_2();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            animator.SetTrigger("change");
            attackTimer -= 3;
        }
        if (currentBossHp == 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //スコア変化～
        {
            if (other.CompareTag("player"))
            {
                Debug.Log("Player touched the Boss! Score -100");
                ScoreManager.Instance.score -= 100;
            }

            if (other.CompareTag("Attack"))
            {
                Debug.Log("Player hit by Boss attack! Score -100");
                ScoreManager.Instance.score -= 100;
            }
            //～スコア変化

            if (CompareTag("cushion"))
            {
                currentBossHp--;
                if (currentBossHp == 10)
                {
                    animator.SetTrigger("change");
                    attackTimer -= 4;
                }
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
        //animation
        animator.SetTrigger("1o2");
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
    // ボスが倒されたときのシーン移動など追加する場合
    private void OnBossDefeated()
    {
        Debug.Log("Boss Defeated! Adding 100 to score.");

        // スコアを追加するなら
        ScoreManager.Instance.score += 400;

        // 次のシーンに移動
        Debug.Log("Loading next scene: " + nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
