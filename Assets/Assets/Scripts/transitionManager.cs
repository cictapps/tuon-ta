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
            StartCoroutine(playWait(1));
        }
        else
        {
            StartCoroutine(playWait(0));
        }

    }

    private IEnumerator playWait(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(levelIndex);
    }
}
