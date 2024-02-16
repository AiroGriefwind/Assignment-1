using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 10; // Amount of ammo to grant the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // Increase player's ammo count
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                
                playerController.IncreaseAmmo(ammoAmount);
            }

            // Destroy the ammo box
            Destroy(gameObject);
        }
    }
}
