using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame_Manager : MonoBehaviour
{
    void Start(){

    }
    public void LoadSceneByName()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
