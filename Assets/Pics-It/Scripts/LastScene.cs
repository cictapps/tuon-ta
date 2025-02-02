using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Method to be called when the "Play Again" button is clicked
    public void PlayAgain()
    {
        // Replace "GameScene" with the name of the first game scene you want to reload
        SceneManager.LoadScene("picks_it_MainMenu");
    }

    // Method to be called when the "Quit" button is clicked
    public void QuitGame()
    {
        // Quits the application
        Debug.Log("Quit Game");
        Application.Quit();

        // If you are testing in the Unity Editor, this will stop play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
