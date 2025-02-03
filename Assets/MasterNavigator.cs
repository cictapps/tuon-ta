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

    // Update is called once per frame
    void Update()
    {
        
    }
}
