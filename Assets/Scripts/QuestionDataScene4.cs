using UnityEngine;

[CreateAssetMenu(fileName = "QuestionScene4", menuName = "ScriptableObjects/QuestionScene4", order = 1)]
public class QuestionDataScene4 : ScriptableObject
{
    public Texture questionImage;
    public string question;
    public string category;
    [Tooltip("The correct answer should always be listed first, they are randomized later")]
    public string[] answers;
}