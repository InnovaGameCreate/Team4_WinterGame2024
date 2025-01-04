using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float attack1Weight;
    public float attack2Weight;
    public float attackWeightSum;
    public float attackKind
    public float attackCoolTimeMin;
    public float attackCoolTimeMax;
    private float attackTimer;
    private float attackTime;



    // Start is called before the first frame update
    void Start()
    {
        attackWeightSum = attack1Weight + attack2Weight;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime> attackTimer)
        {
            attackTime = Random.Range(attackCoolTimeMin, attackCoolTimeMax);
            attackKind = Random.Range(0, attackWeightSum);
        }
    }
}
