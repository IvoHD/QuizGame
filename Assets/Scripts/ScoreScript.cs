using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;
    int scorePoints = 0;
    
    public int getCorrectAnswers()
    {
        return correctAnswers;
    }

    public int getQuestionsSeen()
    {
        return questionsSeen;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int getScoreInPercent()
    {
        return Mathf.RoundToInt((float)correctAnswers / questionsSeen * 100);
    }
    
    public void AddPoints(float currentTime, float maxTime) {
        scorePoints += Mathf.RoundToInt(currentTime / maxTime * 300);
    }

    public int getScorePoints()
    {
        return scorePoints;
    }
}
