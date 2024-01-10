using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public float timePerQuestion;
    float m_curTime;
    int m_rightCount;
    int count = 0;

    private AnswerButton rightAnswerButton;
    private AnswerButton wrongAnswerButton;
    private AnswerButton defaulAnswerButton;
    private SuportButton use50Button;
    private SuportButton useYKButton;

    private void Awake()
    {
        m_curTime = timePerQuestion;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();

        StartCoroutine(TimeCoutingDown());

        UIManager.Ins.SetTimeText("00 : " + m_curTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateQuestion()
    {
                
        QuestionData qs = QuestionManager.Ins.GetRandomQuestion();
        count++ ;
        QuestionController.instance.getQuestionNumber(count);

        if (qs != null)
        {
            UIManager.Ins.SetQuestionText(qs.question);
            string[] wrongAnswer = new string[] { qs.answerA, qs.answerB, qs.answerC };

            UIManager.Ins.ShuffleAnswwer();

            var temp = UIManager.Ins.answerButtons;
            var temp1 = UIManager.Ins.spButton;
            


            if (temp != null && temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                int maxWrongAnswers = 2;
                for (int i = 0; i < temp.Length; i++)
                {
                    int answerId = i;
                    if (string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                        rightAnswerButton = temp[i];
                        temp[i].btnComp.interactable = true;

                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                        temp[i].btnComp.interactable = true;
                        Debug.Log(i);

                        if (wrongAnswerCount <= maxWrongAnswers)
                        {
                            int a = i;
                            temp1[0].btnComp.onClick.AddListener(() => fiftyfifty(a));
                        }
                    }
                           

                    temp[answerId].btnComp.onClick.RemoveAllListeners();
                    temp[answerId].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));

                }
            }
        }
    }
    public void CheckRightAnswerEvent(AnswerButton answerButton)
    {
        StartCoroutine(DelayedCheckRightAnswer(answerButton));
    }
    IEnumerator DelayedCheckRightAnswer(AnswerButton answerButton)
    {
        yield return new WaitForSeconds(2);
        if (answerButton.CompareTag("RightAnswer"))
        {
            m_curTime = timePerQuestion;
            UIManager.Ins.SetTimeText("00 : " + m_curTime);
            m_rightCount++;
            UIManager.Ins.ChangeRightAnswer(answerButton);
            if (m_rightCount == QuestionManager.Ins.questions.Length)
            {
                yield return new WaitForSeconds(2);
                UIManager.Ins.dialog.SetDialogContent(" YOU WIN !");
                UIManager.Ins.dialog.Show(true);
                StopAllCoroutines();
                AudioController.Ins.PlayWinSound();

            }
            else
            {
                yield return new WaitForSeconds(1);
                CreateQuestion();
                UIManager.Ins.ChangeDefaulAnswer(answerButton);
                AudioController.Ins.PlayRightSound();
                Debug.Log("Ban da tra loi dung");
                
            }
        }
        else
        {

            yield return new WaitForSeconds(1);
            UIManager.Ins.ChaneWrongAnswer(answerButton);
            UIManager.Ins.dialog.SetDialogContent(" YOU LOSE !");
            UIManager.Ins.dialog.Show(true);
            AudioController.Ins.PlayWrongtSound();
            AudioController.Ins.PlayLoseSound();
            count = 0;
        }
    }
    IEnumerator TimeCoutingDown()
    {
        yield return new WaitForSeconds(1);
        if (m_curTime > 0)
        {
            m_curTime--;
            StartCoroutine(TimeCoutingDown());
            UIManager.Ins.SetTimeText("00 : " + m_curTime);
        }
        else
        {
            UIManager.Ins.dialog.SetDialogContent(" YOU LOSE !");
            UIManager.Ins.dialog.Show(true);
            StopAllCoroutines();
            AudioController.Ins.PlayLoseSound();
        }
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(1);
    }
    public void Use50()
    {
        UIManager.Ins.Change50(use50Button);
    }

    public void UseYK()
    {
        UIManager.Ins.ChangeYK(useYKButton);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Out()
    {
        Application.LoadLevel("Scene1");
    }
    public void Replay()
    {
        AudioController.Ins.StopMusic();
        Application.LoadLevel("Scene3");
    }

    public void loadScene()
    {
        Application.LoadLevel("Scene2");
    }

    public void PlayScene()
    {
        AudioController.Ins.PlayGame();
        Application.LoadLevel("Scene3");
    }

    public void Setting()
    {
        UIManager.Ins.setting.Show(true);
    }
    public void X()
    {
        UIManager.Ins.setting.Show(false);
    }
    public void fiftyfifty(int a)
    {

        var temp = UIManager.Ins.answerButtons;
        var temp1 = UIManager.Ins.spButton;
        temp[a].SetAnswerNullText();
        temp[a].btnComp.interactable = false;
        temp1[0].btnComp.interactable = false;

    }
}
