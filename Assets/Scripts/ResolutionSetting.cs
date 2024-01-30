using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;

    void Start()
    {
        if (resolutionDropdown == null)
        {
            Debug.LogError("ResolutionManager: TMP_Dropdown is not assigned in the inspector.");
            return;
        }

        resolutionDropdown.ClearOptions();
        LoadResolutions();
        LoadSavedResolution();
    }

    private void LoadResolutions()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void LoadSavedResolution()
    {
        int savedWidth = PlayerPrefs.GetInt("ResolutionWidth", resolutions[currentResolutionIndex].width);
        int savedHeight = PlayerPrefs.GetInt("ResolutionHeight", resolutions[currentResolutionIndex].height);
        SetResolution(savedWidth, savedHeight);
    }

    public void OnResolutionChange(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        SetResolution(resolution.width, resolution.height);
    }

    private void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
        Debug.Log("Resolution set to: "+width+"x"+height);
        SaveResolution(width, height);
    }

    private void SaveResolution(int width, int height)
    {
        PlayerPrefs.SetInt("ResolutionWidth", width);
        PlayerPrefs.SetInt("ResolutionHeight", height);
        PlayerPrefs.Save();
    }
}
