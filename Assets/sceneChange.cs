using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void ChangeScene( int StartGame)
    {
        SceneManager.LoadScene(StartGame);
    }
}

