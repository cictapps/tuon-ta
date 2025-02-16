using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionGame : MonoBehaviour
{
    [SerializeField] private GameObject firstOptionButton;
    [SerializeField] private GameObject secondOptionButton;
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;
    [SerializeField] private Text questionText;
    [SerializeField] private Text letterText;
    [SerializeField] private GameObject feedbackImage; // Image for feedback
    [SerializeField] private GameObject confetti;
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

        GameObject.Find("firstOption").GetComponent<Button>().onClick.AddListener(() => CheckAnswer(0));
        GameObject.Find("secondOption").GetComponent<Button>().onClick.AddListener(() => CheckAnswer(1));
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {

        Debug.Log(GameObject.Find("firstOption").GetComponent<RawImage>());
        
        
        
        GameObject.Find("firstOption").GetComponent<RawImage>().texture = questions[currentQuestionIndex].firstOptionImage.texture;
        GameObject.Find("secondOption").GetComponent<RawImage>().texture = questions[currentQuestionIndex].secondOptionImage.texture;
        letterText.text = questions[currentQuestionIndex].letterQuestion;
        questionText.text = "Diin nga laragway ang nagapakita sang letra " + questions[currentQuestionIndex].phonicQuestion + " ?";
        feedbackImage.SetActive(false);  // Hide feedback image when displaying a new question
        confetti.SetActive(false);
    }

    private void CheckAnswer(int selectedIndex)
    {
        feedbackImage.SetActive(true);  // Show the feedback image
        

        if (selectedIndex != questions[currentQuestionIndex].correctOptionIndex)
        {
            wrongSound.Play();  // Play wrong sound
            GameObject.Find("feedbackImage").GetComponent<RawImage>().texture = wrongImage.texture;  // Show wrong image
            Invoke("RetakeQuestion", 1.5f);  // Add a delay to show feedback, then retake the current question
            return;
        }else{
            correctSound.Play();  // Play correct sound
            confetti.SetActive(true);
        }

        GameObject.Find("feedbackImage").GetComponent<RawImage>().texture = correctImage.texture;

        //feedbackImage.transform.GetComponent<Image>().sprite = correctImage;  // Show correct image

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
        GameObject.Find("feedbackImage").SetActive(false);  // Hide the feedback image
        confetti.SetActive(false);
        DisplayQuestion();  // Re-display the same question without advancing
    }
}
