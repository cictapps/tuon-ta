using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMenu : MonoBehaviour
{
    public void playGame1(){
        SceneManager.LoadSceneAsync(2);  
    }

}
