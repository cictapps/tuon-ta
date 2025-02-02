using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Image quizImage;
    public Button option1Button;
    public Button option2Button;
    public Text feedbackText;

    public Image correctAnswerPopup;
    public Image wrongAnswerPopup;
    public AudioSource audioSource;
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;

    public Text scoreText; // Reference to the score UI Text

    private int score = 0; // Initialize score to 0
    private bool isProcessingAnswer = false; // Flag to prevent multiple question loads

    [System.Serializable]
    public class QuizData
    {
        public Sprite image;
        public string option1;
        public string option2;
        public int correctOption; // 1 or 2
    }

    public QuizData[] quizDataArray;
    private int currentQuestionIndex = 0;
    private bool quizComplete = false;

    void Start()
    {
        if (quizDataArray.Length > 0)
        {
            Debug.Log("Total questions: " + quizDataArray.Length);
            ShuffleQuestions();
            LoadQuestion();
            UpdateScoreText();

            // Clear existing listeners to avoid multiple calls
            option1Button.onClick.RemoveAllListeners();
            option2Button.onClick.RemoveAllListeners();

            // Hook up button listeners
            option1Button.onClick.AddListener(() => CheckAnswer(1));
            option2Button.onClick.AddListener(() => CheckAnswer(2));
        }
        else
        {
            Debug.LogError("Quiz Data Array is empty!");
        }
    }

    private void ShuffleQuestions()
    {
        for (int i = 0; i < quizDataArray.Length; i++)
        {
            QuizData temp = quizDataArray[i];
            int randomIndex = Random.Range(0, quizDataArray.Length);
            quizDataArray[i] = quizDataArray[randomIndex];
            quizDataArray[randomIndex] = temp;
        }

        // Debug the shuffled order to ensure all questions are present
        for (int i = 0; i < quizDataArray.Length; i++)
        {
            Debug.Log("Shuffled question at index " + i + ": " + quizDataArray[i].image.name);
        }
    }

    public void LoadQuestion()
    {
        // Stop if the quiz is complete
        if (quizComplete)
        {
            Debug.Log("Quiz is complete.");
            return;
        }

        Debug.Log("Loading question at index " + currentQuestionIndex);
        QuizData currentQuestion = quizDataArray[currentQuestionIndex];

        if (currentQuestion != null)
        {
            quizImage.sprite = currentQuestion.image;
            option1Button.GetComponentInChildren<Text>().text = currentQuestion.option1;
            option2Button.GetComponentInChildren<Text>().text = currentQuestion.option2;
        }
        else
        {
            Debug.LogError("Current question is null!");
        }
    }

        public void CheckAnswer(int selectedOption)
        {
            if (isProcessingAnswer) return;

            isProcessingAnswer = true;

            QuizData currentQuestion = quizDataArray[currentQuestionIndex];

            if (selectedOption == currentQuestion.correctOption)
            {
                ScoreManager.instance.AddScore(1); // Use ScoreManager to increment score
                StartCoroutine(ShowCorrectAnswerFeedback());
                feedbackText.text = "Tama!";
            }
            else
            {
                StartCoroutine(ShowWrongAnswerFeedback());
                feedbackText.text = "Sala!";
            }

            UpdateScoreText();
        }

    private IEnumerator ShowCorrectAnswerFeedback()
    {
        Debug.Log("Correct answer! Showing pop-up.");
        correctAnswerPopup.gameObject.SetActive(true);
        audioSource.PlayOneShot(correctAnswerSound);

        yield return new WaitForSeconds(1);

        correctAnswerPopup.gameObject.SetActive(false);
        NextQuestion();
    }

    private IEnumerator ShowWrongAnswerFeedback()
    {
        Debug.Log("Wrong answer! Showing pop-up.");
        wrongAnswerPopup.gameObject.SetActive(true);
        audioSource.PlayOneShot(wrongAnswerSound);

        yield return new WaitForSeconds(1);

        wrongAnswerPopup.gameObject.SetActive(false);
        NextQuestion();
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex >= quizDataArray.Length)
        {
            quizComplete = true;
            Debug.Log("Quiz Complete!");
            feedbackText.text = "Congratulations! You've completed the quiz! Your score is: " + score;

            SceneManager.LoadScene("ScoreScene");
        }
        else
        {
            LoadQuestion(); // Load the next question if there are more
        }

        // Reset the flag to allow the next question to be processed
        isProcessingAnswer = false;
    }

        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + ScoreManager.instance.GetScore(); // Update score display using ScoreManager
        }
}
