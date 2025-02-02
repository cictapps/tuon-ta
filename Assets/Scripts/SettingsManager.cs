using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    private bool isMuted = false;

    private void Awake()
    {
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("SettingsManager instance created.");
    }
    else
    {
        Destroy(gameObject);
        Debug.Log("Another SettingsManager instance destroyed.");
    }
    }

    public bool IsMuted
    {
        get { return isMuted; }
        set
        {
            isMuted = value;
            AudioListener.volume = isMuted ? 0 : 1;
        }
    }

    public void ToggleMute()
    {
        IsMuted = !IsMuted;
    }
}