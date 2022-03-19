using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSo> questions = new List<QuestionSo>();
    QuestionSo currentQuestion;
 
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    TimerScript timerScript;
    bool hasAnsweredEarly = true;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreScript scoreScript;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    private void Awake()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
        timerScript = FindObjectOfType<TimerScript>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {
        timerImage.fillAmount = timerScript.getFillFraction();
        if (timerScript.loadNextQestion) {
            if (progressBar.value == progressBar.maxValue)
                isComplete = true;

            GetNextQuestion();
            hasAnsweredEarly = false;
            timerScript.loadNextQestion = false;
        }
        else if (!hasAnsweredEarly && !timerScript.isAnsweringQuestion) {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timerScript.CancelTimer();
        DisplayScore();
    }

    void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex) {
            questionText.text = "Correct!";
            // Image buttonImage = answerButtons[index].GetComponent<Image>();
            // buttonImage.sprite  = correctAnswerSprite;cyc
            scoreScript.IncrementCorrectAnswers();
            scoreScript.AddPoints(timerScript.getCurrentTime(), timerScript.getMaxTime());
        }
        else {
            questionText.text = "Wrong!\nCorrect answer is " + currentQuestion.getPossibleAnswer(correctAnswerIndex);
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count != 0) {
            SetButtonState(true);
            GetRandomQuestion();
            correctAnswerIndex = currentQuestion.getAnswerIndex();
            SetDefaultButtonSprites();
            DisplayQuestion();
            progressBar.value++;
            scoreScript.IncrementQuestionsSeen();
        }
    }

     void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion))
            questions.Remove(currentQuestion);
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.getQuestion();
        TextMeshProUGUI buttonText;

        for (int i = 0; i < answerButtons.Length; i++) {
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getPossibleAnswer(i);
        }
    }

    void DisplayScore()
    {
        scoreText.text = "Score\t\t" + scoreScript.getScoreInPercent() + "%\nPoints\t\t" + scoreScript.getScorePoints();
    }

    void SetButtonState(bool state)
    {
        
        for(int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }
    
        
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;

        }
    }
}
