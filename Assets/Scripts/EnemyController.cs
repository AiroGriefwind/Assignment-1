using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Movement speed of the enemy
    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player's transform by tag (assuming player has "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if collided with a bullet
        if (other.CompareTag("Bullet"))
        {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
