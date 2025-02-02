using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
           StartCoroutine(endTimer());
    }

    IEnumerator endTimer()
    {
        yield return new WaitForSeconds(3);
        animator.Play("fade-out");
        SceneManager.LoadScene(0);
    }
}
