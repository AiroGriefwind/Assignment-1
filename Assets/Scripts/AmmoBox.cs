using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 10; // Amount of ammo to grant the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with ammo box!");

            // Increase player's ammo count
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("Granting ammo to player: " + ammoAmount);
                playerController.IncreaseAmmo(ammoAmount);
            }

            // Destroy the ammo box
            Destroy(gameObject);
        }
    }
}
