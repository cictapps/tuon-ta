using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Retrieve the score from the ScoreManager and display it
        scoreText.text = "ESKOR: " + ScoreManager.instance.GetScore();
    }
}
