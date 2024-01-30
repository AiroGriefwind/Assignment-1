using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPad : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn (e.g., player character)
    public Transform spawnPoint; // The position where the object will spawn

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the interacting object is the player
        {
            SpawnObject();
        }

        
    }

    private void SpawnObject()
    {
        // Instantiate the object and store a reference to it
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Destroy the instantiated object after 5 seconds
        Destroy(spawnedObject, 5f); 
    }
}
