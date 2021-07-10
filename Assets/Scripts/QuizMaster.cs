using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizMaster : MonoBehaviour
{
    private triviaFetcher tFetch;
    private triviaQuestion currentQuestion;
    private GameObject objGamePanel;
    private GameObject objSvar1;
    private GameObject objSvar2;
    private GameObject objSvar3;    
    private GameObject objSvar4;    

    // Start is called before the first frame update
    void Start()
    {
        tFetch = this.gameObject.GetComponent<triviaFetcher>();       
        objGamePanel = GameObject.Find("Text (TMP)");        
        objSvar1 = GameObject.Find("txtSvar1");
        objSvar2 = GameObject.Find("txtSvar2");
        objSvar3 = GameObject.Find("txtSvar3");
        objSvar4 = GameObject.Find("txtSvar4");

    }

    // Update is called once per frame
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
    }

    private void submitAnswer(string v)
    {
        if (v==currentQuestion.correctAnswer)
        {
            Debug.Log("DING!");
            getNextQuestion();
        }
        else
        {
            Debug.Log("NEEEEEEEJ!!!");
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
        //fix mulighed for ekstra visning af samme forkerte svar.. pick, delete, forfra??

        objGamePanel.GetComponent<TextMeshPro>().text = question.question;

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                objSvar1.GetComponent<TextMeshPro>().text = question.correctAnswer;
                objSvar2.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar3.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar4.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                break;
            case 1:
                objSvar3.GetComponent<TextMeshPro>().text = question.correctAnswer;
                objSvar2.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar1.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar4.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                break;
            case 2:
                objSvar2.GetComponent<TextMeshPro>().text = question.correctAnswer;
                objSvar1.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar3.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar4.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                break;
            case 3:
                objSvar4.GetComponent<TextMeshPro>().text = question.correctAnswer;
                objSvar2.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar3.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                objSvar1.GetComponent<TextMeshPro>().text = question.incorrectAnswers[UnityEngine.Random.Range(0, question.incorrectAnswers.Count)];
                break;
            default:
                break;
        }
    }


}
