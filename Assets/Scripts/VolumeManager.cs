using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    //public AudioSource backgroundMusic; // Assign this from the inspector

    private void Start()
    {
        // Initialize the slider's value to match the saved volume or default to 1 (full volume)
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        AudioManager.Instance.SetVolume(volumeSlider.value);

        // Save the new volume setting
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
        PlayerPrefs.Save();
    }
}
