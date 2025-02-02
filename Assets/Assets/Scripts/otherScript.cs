using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherScript : MonoBehaviour
{
    public GameObject creditsTab;
    public GameObject otherTab;

    public void onOtherButton()
    {
        otherTab.SetActive(true);
    }

    public void closeOther()
    {
        otherTab.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void onCredits()
    {
        creditsTab.SetActive(true);
    }

    public void closeCredits()
    {
        creditsTab.SetActive(false);
    }
}
