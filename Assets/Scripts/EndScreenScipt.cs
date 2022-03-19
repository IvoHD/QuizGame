using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScipt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreScript scoreScript;


    void Awake()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "Score:\t" + scoreScript.getScoreInPercent() + "\nPoints:\t" + scoreScript.getScorePoints();
    }
}
