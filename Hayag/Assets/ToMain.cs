using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}