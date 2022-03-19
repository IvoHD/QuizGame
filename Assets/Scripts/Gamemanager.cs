using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    Quiz quiz;
    EndScreenScipt endScreenScript;

    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreenScript = FindObjectOfType<EndScreenScipt>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreenScript.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quiz.isComplete) {
            quiz.gameObject.SetActive(false);
            endScreenScript.gameObject.SetActive(true);
            endScreenScript.ShowFinalScore();
        }
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload current 
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
