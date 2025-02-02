using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class QuestionSetupScene3 : MonoBehaviour
{
    [SerializeField] private List<QuestionDataScene3> questions;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI categoryText;
    [SerializeField] private AnswerButtonScene3[] answerButtons;
    [SerializeField] private RawImage questionImageObject;
    [SerializeField] private GameObject goodJobScreen;
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource incorrectSound;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private List<QuestionState> questionStates = new List<QuestionState>();
    private int currentQuestionIndex = -1;
    private int score = 0;

    private class QuestionState
    {
        public QuestionDataScene3 question;
        public bool isAnswered;
        public bool isCorrect;
        public int selectedAnswerIndex;
        public List<string> randomizedAnswers;
    }

    private void Awake()
    {
        GetQuestionAssets();
    }

    private void Start()
    {
        if (answerButtons == null || answerButtons.Length == 0)
        {
            Debug.LogError("Answer buttons not assigned in the inspector");
            return;
        }

        previousButton.onClick.AddListener(GoToPreviousQuestion);
        nextButton.onClick.AddListener(GoToNextQuestion);

        InitializeQuestions();
        DisplayCurrentQuestion();
    }

    private void GetQuestionAssets()
    {
        questions = new List<QuestionDataScene3>(Resources.LoadAll<QuestionDataScene3>("QuestionsScene3"));
        Debug.Log("Number of questions loaded: " + questions.Count);
    }

    private void InitializeQuestions()
    {
        foreach (var question in questions)
        {
            questionStates.Add(new QuestionState
            {
                question = question,
                isAnswered = false,
                isCorrect = false,
                selectedAnswerIndex = -1,
                randomizedAnswers = RandomizeAnswers(new List<string>(question.answers))
            });
        }
        currentQuestionIndex = 0;
    }

    private void DisplayCurrentQuestion()
    {
        if (currentQuestionIndex < 0 || currentQuestionIndex >= questionStates.Count)
        {
            Debug.LogError("Invalid question index");
            return;
        }

        var currentState = questionStates[currentQuestionIndex];
        QuestionDataScene3 currentQuestion = currentState.question;

        questionText.text = currentQuestion.question;
        categoryText.text = currentQuestion.category;
        if (questionImageObject != null && currentQuestion.questionImage != null)
        {
            questionImageObject.texture = currentQuestion.questionImage;
        }

        string correctAnswer = currentQuestion.answers[0]; // The correct answer is always the first one

        for (int i = 0; i < answerButtons.Length; i++)
        {
            string currentAnswer = currentState.randomizedAnswers[i];
            answerButtons[i].SetAnswerText(currentAnswer);
            answerButtons[i].SetIsCorrect(currentAnswer == correctAnswer);
            answerButtons[i].ResetButtonColor();
            answerButtons[i].SetInteractable(!currentState.isAnswered);
        }

        if (currentState.isAnswered)
        {
            HighlightAnswers(currentState);
        }

        UpdateNavigationButtons();
    }

    private void HighlightAnswers(QuestionState state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i == state.selectedAnswerIndex)
            {
                answerButtons[i].SetButtonColor(state.isCorrect ? Color.green : Color.red);
            }
            else if (answerButtons[i].IsCorrect())
            {
                answerButtons[i].SetButtonColor(Color.green);
            }
        }
    }

    public void AnswerSelected(bool isCorrect, AnswerButtonScene3 clickedButton)
    {
        if (questionStates[currentQuestionIndex].isAnswered)
        {
            return;
        }

        questionStates[currentQuestionIndex].isAnswered = true;
        questionStates[currentQuestionIndex].isCorrect = isCorrect;
        questionStates[currentQuestionIndex].selectedAnswerIndex = System.Array.IndexOf(answerButtons, clickedButton);

        if (isCorrect)
        {
            score++;
            PlaySound(correctSound);
        }
        else
        {
            PlaySound(incorrectSound);
        }

        HighlightAnswers(questionStates[currentQuestionIndex]);
        UpdateNavigationButtons();

        if (IsQuizCompleted())
        {
            StartCoroutine(ShowGoodJobScreen());
        }
    }

    private void GoToPreviousQuestion()
    {
        if (currentQuestionIndex > 0)
        {
            currentQuestionIndex--;
            DisplayCurrentQuestion();
        }
    }

    private void GoToNextQuestion()
    {
        if (currentQuestionIndex < questionStates.Count - 1)
        {
            currentQuestionIndex++;
            DisplayCurrentQuestion();
        }
        else if (IsQuizCompleted())
        {
            StartCoroutine(ShowGoodJobScreen());
        }
    }

    private void UpdateNavigationButtons()
    {
        previousButton.interactable = (currentQuestionIndex > 0);
        nextButton.interactable = (currentQuestionIndex < questionStates.Count - 1) || IsQuizCompleted();
    }

    private bool IsQuizCompleted()
    {
        return questionStates.TrueForAll(q => q.isAnswered);
    }

    private IEnumerator ShowGoodJobScreen()
    {
        yield return new WaitForSeconds(1f);
        quizPanel.SetActive(false);
        goodJobScreen.SetActive(true);
        scoreText.text = $"Your Score: {score} / {questionStates.Count}";
    }

    public void RestartQuiz()
    {
        score = 0;
        currentQuestionIndex = -1;
        questionStates.Clear();
        
        GetQuestionAssets();
        InitializeQuestions();
        
        goodJobScreen.SetActive(false);
        quizPanel.SetActive(true);
        
        DisplayCurrentQuestion();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("hayag_main_menu");
    }

    private void PlaySound(AudioSource sound)
    {
        if (sound == null)
        {
            Debug.LogError("AudioSource is null.");
            return;
        }

        if (SettingsManager.Instance != null && !SettingsManager.Instance.IsMuted)
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarning("Sound is muted or SettingsManager is null.");
        }
    }
    private List<string> RandomizeAnswers(List<string> originalList)
    {
        List<string> newList = new List<string>(originalList);
        int n = newList.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            string value = newList[k];
            newList[k] = newList[n];
            newList[n] = value;
        }
        return newList;
    }
}