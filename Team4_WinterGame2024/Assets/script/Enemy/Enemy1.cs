using UnityEngine;

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
            if (collider.CompareTag("cushion") || collider.CompareTag("player"))
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
