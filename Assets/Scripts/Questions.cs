using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Object/Question", order = 1)]
public class Questions : ScriptableObject
{
    public string letterQuestion;
    public string phonicQuestion;
    public Sprite firstOptionImage;
    public Sprite secondOptionImage;
    public int correctOptionIndex;
    public Sprite feedbackImage;
}
