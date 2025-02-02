using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "QuestionScene2", menuName = "ScriptableObjects/QuestionScene2", order = 1)]
public class QuestionDataScene2 : ScriptableObject
{
    public Texture questionImage;
    public string question;
    public string category;
    [Tooltip("The correct answer should always be listed first, they are randomized later")]
    public string[] answers;
}