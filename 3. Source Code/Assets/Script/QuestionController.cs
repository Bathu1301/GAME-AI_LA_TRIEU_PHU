using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    [SerializeField] TMP_Text textQuestion;
    private int questionNumber;
    public static QuestionController instance;

    private void Awake()
    {
        instance = this;
    }

    public void getQuestionNumber(int questionNumber)
    {
        this.questionNumber = questionNumber;
        textQuestion.text =this.questionNumber.ToString()+" / 15";
    }
}
