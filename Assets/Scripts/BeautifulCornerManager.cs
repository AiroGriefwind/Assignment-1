using UnityEngine;

public class BeautifulCornerManager : MonoBehaviour
{
    public Canvas startCanvas; // Assign your start canvas in the inspector

    // Start is called before the first frame update
    void Start()
    {
        // Freeze the game at the start
        Time.timeScale = 0f;
        // Make sure the start canvas is enabled
        startCanvas.gameObject.SetActive(true);
    }

    // Call this method when the start button is clicked
    public void StartGame()
    {
        // Unfreeze the game
        Time.timeScale = 1f;
        // Hide the start canvas
        startCanvas.gameObject.SetActive(false);
    }
}
