using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    float timeToComplete = 15f;
    float timeToShowAnswer = 5f;

    public bool loadNextQestion;
    float fillFraction;
    public bool isAnsweringQuestion;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion) {
            if(timerValue > 0) {
                fillFraction = timerValue / timeToComplete;
            }
            else {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;
            }
        }
        else {
            if (timerValue > 0) {
                fillFraction = timerValue / timeToShowAnswer;
            }
            else {
                isAnsweringQuestion = true;
                timerValue = timeToComplete;
                loadNextQestion = true;
            }
        }
    }

    public float getFillFraction()
    {
        return fillFraction;
    }

    public float getCurrentTime()
    {
        return timerValue;
    }

    public float getMaxTime()
    {
        return timeToComplete;
    }
}
