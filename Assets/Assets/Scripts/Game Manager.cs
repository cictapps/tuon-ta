using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels;
    public int currentLevel;
    public GameObject particlesGameObject1;
    public ParticleSystem particles1;
    public GameObject particlesGameObject2;
    public ParticleSystem particles2;
    public AudioSource yayAudio;

    private void Start()
    {
        particles1 = particlesGameObject1.GetComponent<ParticleSystem>();
        particles2 = particlesGameObject2.GetComponent<ParticleSystem>();
    }
    public void ifCorrectAns()
    {
        if (currentLevel + 1 != levels.Length)
        {
            yayAudio.Play();
            particles1.Play();
            particles2.Play();
            StartCoroutine(nextLevelTimer());
        }
    }

    private IEnumerator nextLevelTimer()
    {
        yield return new WaitForSeconds(3);
        levels[currentLevel].SetActive(false);
        currentLevel++;
        levels[currentLevel].SetActive(true);
    }
}