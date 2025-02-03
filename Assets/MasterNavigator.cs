using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterNavigator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void NavigateTo(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(sceneName);
    }

    public void BackToPreviousScene()
    {
        // Load the previous scene
        SceneManager.LoadScene("MasterHomeScene");
    }

    public void GoToGamesMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MasterGamesScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
