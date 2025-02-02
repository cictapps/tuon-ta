using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionGame : MonoBehaviour
{
    [SerializeField] private GameObject firstOptionButton;
    [SerializeField] private GameObject secondOptionButton;
    [SerializeField] private Text questionText;
    [SerializeField] private Text letterText;
    [SerializeField] private Image feedbackImage; // Image for feedback
    [SerializeField] private Sprite correctImage; // Image to show for correct answers
    [SerializeField] private Sprite wrongImage; // Image to show for wrong answers
    [SerializeField] private List<Questions> questions;

    private int currentQuestionIndex = 0;

    private void Start()
    {
        PrepareUi();
    }

    private void PrepareUi()
    {
        firstOptionButton.transform.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(0));
        secondOptionButton.transform.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(1));
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        firstOptionButton.transform.GetComponent<Image>().sprite = questions[currentQuestionIndex].firstOptionImage;
        secondOptionButton.transform.GetComponent<Image>().sprite = questions[currentQuestionIndex].secondOptionImage;
        letterText.text = questions[currentQuestionIndex].letterQuestion;
        questionText.text = "Diin nga laragway ang nagapakita sang letra " + questions[currentQuestionIndex].phonicQuestion + " ?";
        feedbackImage.gameObject.SetActive(false);  // Hide feedback image when displaying a new question
    }

    private void CheckAnswer(int selectedIndex)
    {
        feedbackImage.gameObject.SetActive(true);  // Show the feedback image

        if (selectedIndex != questions[currentQuestionIndex].correctOptionIndex)
        {
            feedbackImage.sprite = wrongImage;  // Show wrong image
            Invoke("RetakeQuestion", 1.5f);  // Add a delay to show feedback, then retake the current question
            return;
        }

        feedbackImage.sprite = correctImage;  // Show correct image

        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Count)
{
    SceneManager.LoadScene("pakta_ang_laragway_FinishedScene"); // Replace with your finished scene name
    return;
}

        
        

        // Proceed to the next question after showing feedback
        Invoke("DisplayQuestion", 1.5f);  // Delay for feedback display before the next question
    }

    private void RetakeQuestion()
    {
        feedbackImage.gameObject.SetActive(false);  // Hide the feedback image
        DisplayQuestion();  // Re-display the same question without advancing
    }
}
