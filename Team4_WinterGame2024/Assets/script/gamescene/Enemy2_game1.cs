using UnityEngine;
using System.Collections;

public class Enemy2_game1 : MonoBehaviour
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

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("cushion"))
            {
                ScoreManager.Instance.score += ScoreManager.Instance.E2score;
                Debug.Log("Cushion hit!");
                Destroy(gameObject);
                Destroy(collider.gameObject); // cushionオブジェクトを削除
                break;
            }
            else if (collider.CompareTag("player"))
            {
                ScoreManager.Instance.score -= ScoreManager.Instance.E2damege;
                Debug.Log("Player hit!");
                Destroy(gameObject);
                break;
            }
            ScoreManager.Instance.UpdateScoreDisplay();
        }
    }
}
