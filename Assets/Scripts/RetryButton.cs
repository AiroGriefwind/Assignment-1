using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Replace with your actual game scene name

    public void RetryGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);

        // Any additional reset logic (if required) can be placed here
    }
}
