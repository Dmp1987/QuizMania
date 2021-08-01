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
    private StageManager kategorina;


    //GameObjects
    public AudioClip answerWrongSFX;
    public AudioClip answerSFX;
    public AudioClip looseSFX;

    private AudioSource SFXsource;

    //GameStats
    int hp;
    int HighScore;
    int currentCombo;

    void Start()
    {
        kategorina = this.gameObject.GetComponent<StageManager>();
        tFetch = this.gameObject.GetComponent<triviaFetcher>();

        SFXsource = this.GetComponent<AudioSource>();
               
        hp = 3;
        HighScore = 0;
        currentCombo = 0;

        kategorina.refreshStats(currentCombo, HighScore, hp);

        //StartCoroutine("waitForTrivia");
    }

    //private void waitForTrivia()
    //{
    //    while (!this.tFetch.isListReady)
    //    {
    //        if (this.tFetch.isListReady)
    //        {
    //            tFetch.getNextQuestion();
    //            break;
    //        }
    //    }
    //    return;
    //}

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
                    submitAnswer(hit.transform.GetComponentInParent<TextMeshPro>().text, hit);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            getNextQuestion();
        }
    }

    private void submitAnswer(string v, RaycastHit hit)
    {
        if (v==currentQuestion.correctAnswer)
        {         
            currentCombo++;
            if (currentCombo>HighScore)
            {
                HighScore++;
            }
            SFXsource.PlayOneShot(answerSFX,1f);
            kategorina.fireParticles();
            kategorina.refreshStats(currentCombo, HighScore, hp);
            kategorina.colorText(true, hit);
            getNextQuestion();
        }
        else
        {                        
            hp--;                   
            if (hp==0)
            {                
                //Do losing logic (show highscore screen?)
                hp = 3;
                currentCombo = 0;
                SFXsource.PlayOneShot(looseSFX);
                kategorina.colorText(true, hit);
                kategorina.refreshStats(currentCombo, HighScore, hp);
                getNextQuestion();
                return;
            }
            
            SFXsource.PlayOneShot(answerWrongSFX,1f);
            kategorina.colorText(false, hit);
            
            kategorina.refreshStats(currentCombo, HighScore, hp);            
        }
    }

    private void getFirstQuestion() 
    {
        currentQuestion = tFetch.getSpecificQuestion(0);
        kategorina.refreshGamepanel(currentQuestion);
    }



    private void getNextQuestion() 
    {
        currentQuestion = tFetch.getNextQuestion();
        kategorina.refreshGamepanel(currentQuestion);
    }





}
