// This script contains the information for a trivia question
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class TriviaQuestionData : ScriptableObject
{
    public Texture QuestionImage;
    public string question;
    public string category;
    [Tooltip("The correct answer should always be listed first, they are ranzomized later")]
    public string[] answers;
}