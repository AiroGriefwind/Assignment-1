using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab; // Reference to the ammo box prefab
    public float spawnInterval = 10f; // Time interval between spawns
    public Transform groundTransform; // Reference to the ground transform where ammo boxes will spawn

    void Start()
    {
        // Start the coroutine to spawn ammo boxes
        StartCoroutine(SpawnAmmoBoxesRoutine());
    }

    IEnumerator SpawnAmmoBoxesRoutine()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Spawn an ammo box
            SpawnAmmoBox();
        }
    }

    void SpawnAmmoBox()
    {
        // Generate a random position within the ground area
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the ammo box at the spawn position
        Instantiate(ammoBoxPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Get the size of the ground collider
        Vector3 groundSize = groundTransform.localScale;

        // Calculate random x and z positions within the ground area
        float randomX = Random.Range(-groundSize.x / 2f, groundSize.x / 2f);
        float randomZ = Random.Range(-groundSize.z / 2f, groundSize.z / 2f);

        // Set the y position slightly above the ground to ensure it drops down
        float spawnHeight = groundTransform.position.y + groundSize.y / 2f + 1f;

        // Return the random spawn position
        return new Vector3(randomX, spawnHeight, randomZ);
    }
}
