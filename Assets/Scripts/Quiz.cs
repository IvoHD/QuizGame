using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    TimerScript timerScript;
    private void Start()
    {
        timerScript = GetComponent<TimerScript>();
        correctAnswerIndex = question.getAnswerIndex();
        GetNextQuestion();
    }

    private void Update()
    {
        timerImage.fillAmount = timerScript.getFillFraction();
        if (timerScript.loadNextQestion) {
            GetNextQuestion();
            timerScript.loadNextQestion = false;
        }
    }
    public void OnAnswerSelected(int index)
    {
        if (index == correctAnswerIndex) {
            questionText.text = "Correct!";
            // Image buttonImage = answerButtons[index].GetComponent<Image>();
            // buttonImage.sprite  = correctAnswerSprite;cyc
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else {
            questionText.text = "Wrong!\nCorrect answer is " + question.getPossibleAnswer(correctAnswerIndex);
            answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        SetButtonState(false);
        timerScript.CancelTimer();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.getQuestion();
        TextMeshProUGUI buttonText;

        for (int i = 0; i < answerButtons.Length; i++) {
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getPossibleAnswer(i);
        }
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
