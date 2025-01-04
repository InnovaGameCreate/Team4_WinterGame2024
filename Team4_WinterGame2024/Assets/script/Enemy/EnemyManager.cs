using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        if (spawnPoints.Length > 0)
        {
            SpawnEnemies();
        }
        else
        {
            Debug.LogWarning("No spawn points assigned.");
        }
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
