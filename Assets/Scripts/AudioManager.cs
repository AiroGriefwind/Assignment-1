using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource backgroundMusic;
    private float musicVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            backgroundMusic = GetComponent<AudioSource>();
            LoadVolumeSetting();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        backgroundMusic.volume = musicVolume;
        SaveVolumeSetting();
    }

    private void LoadVolumeSetting()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        backgroundMusic.volume = musicVolume;
    }

    private void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }
}
