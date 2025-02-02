using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    void Awake()
    {
        // If there's no instance, set this object as the singleton instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate if instance already exists
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}

