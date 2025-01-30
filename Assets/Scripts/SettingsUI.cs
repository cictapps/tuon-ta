using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private string mainMenuSceneName = "hayag_main_menu";

    private void Start()
    {
        if (muteToggle == null)
        {
            Debug.LogError("Mute toggle not assigned in SettingsUI");
            return;
        }

        muteToggle.isOn = SettingsManager.Instance.IsMuted;
        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseSettings);
        }
        else
        {
            Debug.LogError("Close button not assigned in SettingsUI");
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
        else
        {
            Debug.LogError("Main menu button not assigned in SettingsUI");
        }
    }

    private void OnMuteToggleChanged(bool isMuted)
    {
        SettingsManager.Instance.IsMuted = isMuted;
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Settings panel not assigned in SettingsUI");
        }
    }

    private void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Settings panel not assigned in SettingsUI");
        }
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}