using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionManager : MonoBehaviour
{
    public Animator transition;
    public endScript endScreen;
    public void playButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(playWait("paktakon_MenuScene"));
        }
        else
        {
            StartCoroutine(playWait("paktakon_LevelScene"));
        }

    }

    private IEnumerator playWait(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(levelName);
    }
}
