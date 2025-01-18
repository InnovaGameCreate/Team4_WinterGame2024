using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Cushion_move : MonoBehaviour
{
    [SerializeField] public float cushionLifetime;
    [SerializeField] public float power;

    private Rigidbody cushionRb;
    // Start is called before the first frame update
    void Start()
    {
        CushionLife();
        cushionRb = GetComponent<Rigidbody>();
        cushionRb.AddForce(Vector3.right * power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        cushionLifetime -= Time.deltaTime;
        if (cushionLifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂�����A���̃I�u�W�F�N�g���폜����
        if (collision.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
    }
    void CushionLife()
    {
        cushionLifetime -= Time.deltaTime;
        if (cushionLifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}