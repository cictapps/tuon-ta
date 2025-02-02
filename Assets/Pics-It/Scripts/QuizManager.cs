using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManager for scene management

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private QuizDataScriptable questionData;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private WordData[] answerWordArray;
    [SerializeField]
    private WordData[] optionsWordArray;

    [SerializeField]
    private AudioClip correctAnswerClip; // Audio clip for correct answer
    private AudioSource audioSource; // Reference to the AudioSource

    private char[] charArray;
    private int currentAnswerIndex = 0;
    private bool correctAnswer = true;
    private List<int> selectedWordIndex;
    private int currentQuestionIndex = 0;
    private GameStatus gameStatus = GameStatus.Playing;
    private string answerWord;
    private int score = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        selectedWordIndex = new List<int>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void Start()
    {
        SetQuestion();
    }

    private void SetQuestion()
    {
        if (currentQuestionIndex >= questionData.questions.Count)
        {
            Debug.Log("All questions completed!");
            gameover.SetActive(true); // Game over if no more questions
            // Load the new scene when all questions are finished
            SceneManager.LoadScene("picks_it_LastScene"); 
            return;
        }

        currentAnswerIndex = 0;
        selectedWordIndex.Clear();
        questionImage.sprite = questionData.questions[currentQuestionIndex].questionImage;
        answerWord = questionData.questions[currentQuestionIndex].answer;

        Debug.Log("Setting question: " + (currentQuestionIndex + 1) + " Answer: " + answerWord);

        ResetQuestion();

        List<char> letterList = new List<char>(answerWord.Length + optionsWordArray.Length);

        foreach (char c in answerWord.ToUpper())
        {
            letterList.Add(c);
        }

        int randomLettersCount = optionsWordArray.Length - answerWord.Length;
        for (int i = 0; i < randomLettersCount; i++)
        {
            letterList.Add((char)UnityEngine.Random.Range(65, 91)); // Random letters A-Z
        }

        charArray = ShuffleList.ShuffleListItems(letterList).ToArray();
        SetOptions(charArray);
        currentQuestionIndex++;
        gameStatus = GameStatus.Playing;
    }

    private void SetOptions(char[] shuffledLetters)
    {
        for (int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].SetChar(shuffledLetters[i]);
        }
        Debug.Log("Options set: " + new string(shuffledLetters));
    }

    public void SelectedOption(WordData wordData)
    {
        if (gameStatus != GameStatus.Playing || currentAnswerIndex >= answerWord.Length) return;

        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;

        if (currentAnswerIndex >= answerWord.Length)
        {
            correctAnswer = true;

            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }

            if (correctAnswer)
            {
                score += 50;
                Debug.Log("Correct answer! Score: " + score);

                if (audioSource != null && correctAnswerClip != null)
                {
                    audioSource.PlayOneShot(correctAnswerClip);
                    StartCoroutine(WaitForAudioAndNextQuestion());
                }
                else
                {
                    MoveToNextQuestion();
                }
            }
            else
            {
                Debug.Log("Incorrect answer.");
            }
        }
    }

    private IEnumerator WaitForAudioAndNextQuestion()
    {
        yield return new WaitForSeconds(correctAnswerClip.length);
        MoveToNextQuestion();
    }

    private void MoveToNextQuestion()
    {
        if (currentQuestionIndex < questionData.questions.Count)
        {
            gameStatus = GameStatus.Next;
            SetQuestion();
        }
        else
        {
            gameover.SetActive(true); // End of game
            Debug.Log("Game Over. No more questions.");

            // Load the new scene when all questions are finished
            SceneManager.LoadScene("picks_it_LastScene");
        }
    }

    private void ResetQuestion()
    {
        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');
        }

        for (int i = answerWord.Length; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].gameObject.SetActive(true);
        }
    }

    public void ResetLastWord()
    {
        if (selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            optionsWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count - 1);
            currentAnswerIndex--;
            answerWordArray[currentAnswerIndex].SetChar('_');
        }
    }

    // New method to reshuffle letters
    public void ReshuffleLetters()
    {
        charArray = ShuffleList.ShuffleListItems(charArray.ToList()).ToArray();
        SetOptions(charArray); // Reassign the shuffled characters to the options
        Debug.Log("Letters reshuffled.");
    }
}

[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}

public enum GameStatus
{
    Playing,
    Next
}
