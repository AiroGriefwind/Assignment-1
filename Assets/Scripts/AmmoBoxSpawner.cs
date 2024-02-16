using UnityEngine;

public class AmmoBoxSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab; // Reference to the collectible ammo box prefab
    public Transform ground; // Reference to the ground object

    public Vector3 spawnAreaSize = new Vector3(10f, 1f, 10f); // Size of the spawn area

    private void Start()
    {
        SpawnAmmoBox();
    }

    private void SpawnAmmoBox()
    {
        // Calculate random position within the spawn area
        Vector3 randomPosition = ground.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            spawnAreaSize.y,
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        // Instantiate the collectible ammo box at the random position
        Instantiate(ammoBoxPrefab, randomPosition, Quaternion.identity);
    }
}
