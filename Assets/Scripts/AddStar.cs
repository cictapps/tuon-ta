using UnityEngine;

public class AddStar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
