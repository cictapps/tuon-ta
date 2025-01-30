using UnityEngine;

[CreateAssetMenu(fileName = "QuestionScene3", menuName = "ScriptableObjects/QuestionScene3", order = 1)]
public class QuestionDataScene3 : ScriptableObject
{
    public Texture questionImage;
    public string question;
    public string category;
    [Tooltip("The correct answer should always be listed first, they are randomized later")]
    public string[] answers;
}