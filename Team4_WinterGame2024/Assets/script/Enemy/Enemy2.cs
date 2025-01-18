using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 1f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(JumpRoutine());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cushion"))
        {
            Destroy(gameObject); 
        }
    }

    IEnumerator JumpRoutine()
    {
        while (true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            yield return new WaitForSeconds(jumpInterval);
        }
    }
}
