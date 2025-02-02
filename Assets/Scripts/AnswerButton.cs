using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private QuestionSetup questionSetup;
    private Button button;
    private Graphic graphicComponent;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on AnswerButton");
        }

        // Try to get Image component first, if not found, try to get any Graphic component
        graphicComponent = GetComponent<Graphic>();
        if (graphicComponent == null)
        {
            graphicComponent = GetComponent<Graphic>();
        }

        if (graphicComponent == null)
        {
            Debug.LogError("No suitable Graphic component found on AnswerButton. Make sure it has an Image or other Graphic component.");
        }
    }

    public void SetAnswerText(string newText)
    {
        if (answerText != null)
        {
            answerText.text = newText;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not assigned to AnswerButton");
        }
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }

    public void OnClick()
    {
        if (questionSetup != null)
        {
            questionSetup.AnswerSelected(isCorrect, this);
        }
        else
        {
            Debug.LogError("QuestionSetup not assigned to AnswerButton");
        }
    }

    public void SetButtonColor(Color color)
    {
        if (graphicComponent != null)
        {
            graphicComponent.color = color;
        }
        else
        {
            Debug.LogError("No suitable Graphic component found on AnswerButton");
        }
    }

    public void ResetButtonColor()
    {
        if (graphicComponent != null)
        {
            graphicComponent.color = Color.white;
        }
        else
        {
            Debug.LogError("No suitable Graphic component found on AnswerButton");
        }
    }

    public void SetInteractable(bool interactable)
    {
        if (button != null)
        {
            button.interactable = interactable;
        }
        else
        {
            Debug.LogError("Button component not found on AnswerButton");
        }
    }
}