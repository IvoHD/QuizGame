using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "NewQuestion")] //To Create new QuestionsSO in Unity
public class QuestionSo : ScriptableObject
{
    [TextArea(2, 6)]            //Controll size from textbox inside inspector (minLines, maxLines)
    [SerializeField] string question = "Enter Question here";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string getQuestion()
    {
        return question;
    }

    public int getAnswerIndex()
    {
        return correctAnswerIndex; 
    }
    public string getPossibleAnswer(int AnswerIndex)
    {
        return Answers[AnswerIndex];
    }
}
