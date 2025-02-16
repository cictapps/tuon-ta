using UnityEngine;
using TMPro;

public class Awards : MonoBehaviour
{
    public TextMeshProUGUI starCountText;
    int starCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starCount = PlayerPrefs.GetInt("stars");
        starCountText.text = starCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
