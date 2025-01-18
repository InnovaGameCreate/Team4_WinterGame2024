using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 1f;
    public float destroyDistance = 0.5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(JumpRoutine());
    }


    IEnumerator JumpRoutine()
    {
        while (true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            yield return new WaitForSeconds(jumpInterval);
        }
    }
    void Update()
    {
        CheckCollision();
    }
    void CheckCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, destroyDistance);
        bool scoreUpdated = false;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("cushion"))
            {
                ScoreManager.Instance.score += 600;
                Debug.Log("Cushion hit! Score: " + 600);
                Destroy(collider.gameObject); // cushion�I�u�W�F�N�g���폜
                scoreUpdated = true;
                break;
            }
            else if (collider.CompareTag("player"))
            {
                ScoreManager.Instance.score -= 400;
                Debug.Log("Player hit! Score: " + -400);
                Destroy(gameObject);
                break;
            }
            ScoreManager.Instance.UpdateScoreDisplay();
        }

        if (scoreUpdated)
        {
            ScoreManager.Instance.UpdateScoreDisplay();
            Destroy(gameObject); // Enemy�I�u�W�F�N�g���폜

    private void OnCollisionEnter(Collision collision)
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
