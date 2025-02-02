using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadSceneAsync(8);  
    }

    public void MgaDuagBack(){
        SceneManager.LoadSceneAsync(7);  
    }

    public void QuitGame(){
        Application.Quit();
    }
}
