using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the instruction scene
        SceneManager.LoadScene("pakta_ang_laragway_InstructionScene");  // Replace with the actual name of your instruction scene
    }
}
