using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UIManager : MonoBehaviour
{
    public static UIManager Ins;
    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public Dialog setting;
    public DialogBarChart dialogBarChart;
    public AnswerButton[] answerButtons;
    public SuportButton[] spButton;
    public Sprite rightAnswer;
    public Sprite wrongAnswer;
    public Sprite defaulAnswer;
    public Sprite use50;
    public Sprite useYK;

    public void Awake()
    {
        MakeSingleton();
    }

    public void SetTimeText(string content)
    {
        if (timeText)
            timeText.text = content;
    }

    public void SetQuestionText(string content)
    {
        if (questionText)
            questionText.text = content;
    }

    public void ShuffleAnswwer()
    {
        if (answerButtons != null && answerButtons.Length > 0)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (answerButtons[i])
                {
                    answerButtons[i].tag = "Untagged";
                }
            }
            int randIdx = Random.Range(0, answerButtons.Length);

            if (answerButtons[randIdx])
            {
                answerButtons[randIdx].tag = "RightAnswer";
            }
        }
    }
    public void ChangeRightAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = rightAnswer;
    }

    public void ChaneWrongAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = wrongAnswer;
    }

    public void ChangeDefaulAnswer(AnswerButton answerButton)
    {
        answerButton.GetComponent<Image>().sprite = defaulAnswer;
    }
    public void Change50(SuportButton spButton)
    {
        //spButton.GetComponent<Image>().sprite = use50;
    }
    public void ChangeYK(SuportButton spButton)
    {
        //spButton.GetComponent<Image>().sprite = useYK;
    }
    public void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void DisableButton(int buttonIndex)
    {
        // Kiểm tra xem chỉ số có hợp lệ không
        if (buttonIndex >= 0 && buttonIndex < answerButtons.Length)
        {
            AnswerButton buttonToDisable = answerButtons[buttonIndex];

            // Kiểm tra xem buttonToDisable có tồn tại và có thành phần Button không
            if (buttonToDisable != null && buttonToDisable.btnComp != null)
            {
                // Vô hiệu hóa nút
                buttonToDisable.btnComp.interactable = false;
            }
        }
        else
        {
            Debug.LogError("Invalid button index.");
        }
    }
}
