using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene("hayag_main_menu");
    }
    public void NextButton() {
        SceneManager.LoadSceneAsync(0);  
    }
}