using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPad : MonoBehaviour
{
    public string gameOverSceneName = "GameOver"; // Name of the gameover scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the death pad
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Load the gameover scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}
