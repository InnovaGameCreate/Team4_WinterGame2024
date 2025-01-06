using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed = 2.0f;  
    public float destroyDistance = 0.5f;  

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        CheckCollision();
    }

    void CheckCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, destroyDistance);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("cushion"))
            {
                ScoreManager.Instance.score += 400;
                Debug.Log("Cushion hit! Score: " + 400);
                Destroy(gameObject);
                break;
            }
            else if (collider.CompareTag("player"))
            {
                ScoreManager.Instance.score -= 200;
                Debug.Log("Player hit! Score: " + -200);
                Destroy(gameObject);
                break;
            }
            ScoreManager.Instance.UpdateScoreDisplay();
        }
    }
}
