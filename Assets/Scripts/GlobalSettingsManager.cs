using UnityEngine;
using UnityEngine.UI;

public class GlobalSettingsManager : MonoBehaviour
{
     
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource[] soundEffects;
    [SerializeField] private Toggle backgroundMusicButton;
    [SerializeField] private Toggle soundEffectsButton;

    public static GlobalSettingsManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    public void ToggleBackgroundMusic()
    {
        Debug.Log("Background Music Toggled");
        Debug.Log(PlayerPrefs.GetInt("BackgroundMusic"));
        
        if (PlayerPrefs.GetInt("BackgroundMusic") == 1)
        {
            PlayerPrefs.SetInt("BackgroundMusic", 0);
            backgroundMusic.mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("BackgroundMusic", 1);
            backgroundMusic.mute = false;
        }
    }

    public void ToggleSoundEffects()
    {
        if (PlayerPrefs.GetInt("SoundEffects") == 0)
        {
            PlayerPrefs.SetInt("SoundEffects", 1);
            foreach (AudioSource soundEffect in soundEffects)
            {
                soundEffect.mute = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundEffects", 0);
            foreach (AudioSource soundEffect in soundEffects)
            {
                soundEffect.mute = true;
            }
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

                if (PlayerPrefs.GetInt("BackgroundMusic") == 1)
        {
            backgroundMusic.mute = false;
            Debug.Log("Background Music is not muted");
            if (backgroundMusicButton != null)
            {
                backgroundMusicButton.isOn = true;
            }
        }
        else
        {
            Debug.Log("Background Music is muted");
            backgroundMusic.mute = true;
            if (backgroundMusicButton != null)
            {
                backgroundMusicButton.isOn = false;
            }
        }

        if (PlayerPrefs.GetInt("SoundEffects") == 0)
        {
            foreach (AudioSource soundEffect in soundEffects)
            {
                soundEffect.mute = true;
            }
            if (soundEffectsButton != null)
            {
                soundEffectsButton.isOn = false;
            }
        }
        else
        {
            foreach (AudioSource soundEffect in soundEffects)
            {
                soundEffect.mute = false;
            }
            if (soundEffectsButton != null)
            {
                soundEffectsButton.isOn = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
