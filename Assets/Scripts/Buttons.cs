using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Loading: " + sceneName);
    }

    public void closeApplication(){
        Application.Quit();
        Debug.Log("Closing Application.");
    }
}
