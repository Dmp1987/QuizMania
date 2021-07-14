using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizMaster : MonoBehaviour
{
    //Classes n Structs
    private triviaFetcher tFetch;
    private triviaQuestion currentQuestion;

    //GameObjects
    private GameObject txtHigh;
    private GameObject txtHealth;
    private GameObject objGamePanel;
    private GameObject objSvar1;
    private GameObject objSvar2;
    private GameObject objSvar3;    
    private GameObject objSvar4;

    //GameStats
    int hp;
    int HighScore;
    int currentCombo;

    void Start()
    {
        tFetch = this.gameObject.GetComponent<triviaFetcher>();       
        objGamePanel = GameObject.Find("txtQuestionBoard");        
        objSvar1 = GameObject.Find("txtSvar1");
        objSvar2 = GameObject.Find("txtSvar2");
        objSvar3 = GameObject.Find("txtSvar3");
        objSvar4 = GameObject.Find("txtSvar4");
        txtHigh = GameObject.Find("txtHighscore");
        txtHealth = GameObject.Find("txtHP");

        hp = 3;
        HighScore = 0;
        currentCombo = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {                
                if (hit.transform != null)
                {
                    submitAnswer(hit.transform.GetComponentInParent<TextMeshPro>().text);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            getNextQuestion();
        }
    }

    private void submitAnswer(string v)
    {
        if (v==currentQuestion.correctAnswer)
        {
            Debug.Log("DING!");
            currentCombo++;
            if (currentCombo>HighScore)
            {
                HighScore++;
            }
            refreshStats();
            getNextQuestion();
        }
        else
        {
            Debug.Log("NEEEEEEEJ!!!");
            currentCombo = 0;
            hp--;            
            if (hp==0)
            {
                Debug.Log("dead");
                HighScore = 0;
                currentCombo = 0;
                hp = 3;
                getNextQuestion();
            }
            refreshStats();            
        }
    }

    private void getFirstQuestion() 
    {
        currentQuestion = tFetch.getSpecificQuestion(0);
        refreshGamepanel(currentQuestion);
    }

    private void getNextQuestion() 
    {
        currentQuestion = tFetch.getNextQuestion();
        refreshGamepanel(currentQuestion);
    }


    private void refreshGamepanel(triviaQuestion question)
    {
        refreshStats();        

        objGamePanel.GetComponent<TextMeshPro>().text = question.question;
        GameObject[] answerButtonsText = { objSvar1, objSvar2, objSvar3, objSvar4 };        

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:                
                objSvar1.GetComponent<TextMeshPro>().text = question.correctAnswer;

                int answerPick = UnityEngine.Random.Range(1, question.incorrectAnswers.Count - 1);                                
                answerPick--;                

                foreach (GameObject objSvar in answerButtonsText)
                {
                    if (objSvar!=objSvar1)
                    {
                        objSvar.GetComponent<TextMeshPro>().text = question.incorrectAnswers[answerPick];                        
                        answerPick++;
                    }                    
                }
                break;
            case 1:
                objSvar2.GetComponent<TextMeshPro>().text = question.correctAnswer;

                answerPick = UnityEngine.Random.Range(1, question.incorrectAnswers.Count - 1);
                answerPick--;

                foreach (GameObject objSvar in answerButtonsText)
                {
                    if (objSvar != objSvar2)
                    {
                        objSvar.GetComponent<TextMeshPro>().text = question.incorrectAnswers[answerPick];
                        answerPick++;
                    }
                }
                break;
            case 2:
                objSvar3.GetComponent<TextMeshPro>().text = question.correctAnswer;

                answerPick = UnityEngine.Random.Range(1, question.incorrectAnswers.Count - 1);
                answerPick--;

                foreach (GameObject objSvar in answerButtonsText)
                {
                    if (objSvar != objSvar3)
                    {
                        objSvar.GetComponent<TextMeshPro>().text = question.incorrectAnswers[answerPick];
                        answerPick++;
                    }
                }
                break;
            case 3:
                objSvar4.GetComponent<TextMeshPro>().text = question.correctAnswer;

                answerPick = UnityEngine.Random.Range(1, question.incorrectAnswers.Count - 1);
                answerPick--;

                foreach (GameObject objSvar in answerButtonsText)
                {
                    if (objSvar != objSvar4)
                    {
                        objSvar.GetComponent<TextMeshPro>().text = question.incorrectAnswers[answerPick];
                        answerPick++;
                    }
                }
                break;
            default:
                break;
        }
    }

    private void refreshStats()
    {
        txtHigh.GetComponent<TextMeshPro>().text = "Current: " + currentCombo + " Highscore: " + HighScore;
        txtHealth.GetComponent<TextMeshPro>().text = "HP: " + hp;
    }
}
