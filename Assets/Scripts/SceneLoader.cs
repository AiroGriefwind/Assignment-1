using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string targetSceneName = "MainMenu"; // Default scene name

    private void Start()
    {
        // Apply saved resolution settings
        ApplyResolutionSettings();
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    private void ApplyResolutionSettings()
    {
        // Check if the resolution settings have been saved
        if (PlayerPrefs.HasKey("ResolutionWidth") && PlayerPrefs.HasKey("ResolutionHeight"))
        {
            // Retrieve the saved resolution settings
            int width = PlayerPrefs.GetInt("ResolutionWidth");
            int height = PlayerPrefs.GetInt("ResolutionHeight");
            bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1;

            // Apply the resolution settings
            Screen.SetResolution(width, height, isFullScreen);
        }
    }
}
