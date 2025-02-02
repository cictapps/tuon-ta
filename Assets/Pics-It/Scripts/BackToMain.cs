using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Name of the main menu scene (make sure it matches exactly)
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    // Method to be called when the button is clicked
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("picks_it_MainMenu");
    }
}
