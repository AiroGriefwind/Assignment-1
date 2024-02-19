using System.Collections;
using UnityEngine;

public class SpawnPad : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform spawnPoint; // The position where the enemy will spawn
    public float minSpawnInterval = 3f; // Minimum time between enemy spawns
    public float maxSpawnInterval = 8f; // Maximum time between enemy spawns

    void Start()
    {
        // Start spawning enemies at regular intervals
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            // Wait for a random time before spawning the next enemy
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Spawn enemy at the spawn point
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy at the spawn point position and rotation
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Optionally, you can add additional setup for the spawned enemy here
    }
}
