using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPad : MonoBehaviour
{
    public List<GameObject> objectPool; // List to hold a pool of objects
    public Transform spawnPoint; // The position where the object will spawn

    void Start()
    {
        // Initialize object pool
        //objectPool = new List<GameObject>();

        InitializeObjectPool();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the interacting object is the player
        {
            // Spawn object using coroutine
            StartCoroutine(SpawnObjectCoroutine());
        }
    }

    // Coroutine for object spawning
    // Coroutine for object spawning
    IEnumerator SpawnObjectCoroutine()
    {
        while (true)
        {
            // Wait for a random time before spawning next object
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            // Randomly select an object from the pool
            GameObject objToSpawn = objectPool[Random.Range(0, objectPool.Count)];

            // Instantiate the object at the spawn point
            GameObject spawnedObject = Instantiate(objToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Set the spawned object as active
            spawnedObject.SetActive(true);
        }
    }


    // Initialize object pool
    void InitializeObjectPool()
    {
        // Add objects to the pool
        // You can add different types of objects to the pool here
        //objectPool.Add(Resources.Load<GameObject>("Cube"));
        //objectPool.Add(Resources.Load<GameObject>("Sphere"));

        // Set all objects in the pool as inactive initially
        foreach (GameObject obj in objectPool)
        {
            obj.SetActive(false);
        }
    }

    // Implement shuffle system by shuffling the object pool
    void ShuffleObjectPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            GameObject temp = objectPool[i];
            int randomIndex = Random.Range(i, objectPool.Count);
            objectPool[i] = objectPool[randomIndex];
            objectPool[randomIndex] = temp;
        }
    }
}
