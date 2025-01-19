using UnityEngine;

public class Enemy1_game1 : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float destroyDistance = 0.5f;
    public float moveDistance = 5.0f;
    private Vector3 startPosition;
    private Vector3 direction = Vector3.left;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction = -direction;
            startPosition = transform.position;
        }

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
                ScoreManager.Instance.score += 400;
                Debug.Log("Cushion hit! Score: +400");
                Destroy(collider.gameObject); // cushionオブジェクトを削除
                scoreUpdated = true;
                break;
            }
            else if (collider.CompareTag("player"))
            {
                ScoreManager.Instance.score -= 200;
                Debug.Log("Player hit! Score: -200");
                scoreUpdated = true;
                break;
            }
        }

        if (scoreUpdated)
        {
            ScoreManager.Instance.UpdateScoreDisplay();
            Destroy(gameObject); // Enemyオブジェクトを削除
        }
    }
}
