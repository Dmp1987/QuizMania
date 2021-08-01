using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public ParticleSystem celebrateParticles;
    private GameObject txtHigh;
    private GameObject txtHealth;
    private GameObject objGamePanel;
    private GameObject objSvar1;
    private GameObject objSvar2;
    private GameObject objSvar3;
    private GameObject objSvar4;    

    void Start()
    {       
        objGamePanel = GameObject.Find("txtQuestionBoard");
        objSvar1 = GameObject.Find("txtSvar1");
        objSvar2 = GameObject.Find("txtSvar2");
        objSvar3 = GameObject.Find("txtSvar3");
        objSvar4 = GameObject.Find("txtSvar4");
        txtHigh = GameObject.Find("txtHighscore");
        txtHealth = GameObject.Find("txtHP");
    }

    public void colorText(bool reset, RaycastHit target)
    {
        if (reset)
        {
            GameObject[] answerButtons = GameObject.FindGameObjectsWithTag("answerButton");
            foreach (GameObject item in answerButtons)
            {
                item.GetComponentInParent<TextMeshPro>().color = Color.white;
            }
        }
        else
        {
            target.transform.GetComponentInParent<TextMeshPro>().color = Color.red;
        }
    }

    public void fireParticles() 
    {
        celebrateParticles.Play();
    }

    public void refreshGamepanel(triviaQuestion question)
    {        
        
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
                    if (objSvar != objSvar1)
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

    public void refreshStats(int currentCombo, int HighScore, int hp)
    {
        txtHigh.GetComponent<TextMeshPro>().text = "Current: " + currentCombo + " Highscore: " + HighScore;
        txtHealth.GetComponent<TextMeshPro>().text = "HP: " + hp;

        switch (hp)
        {
            case 3:
                txtHealth.GetComponent<TextMeshPro>().color = Color.green;
                break;
            case 2:
                txtHealth.GetComponent<TextMeshPro>().color = Color.yellow;
                break;
            case 1:
                txtHealth.GetComponent<TextMeshPro>().color = Color.red;
                break;
            default:
                txtHealth.GetComponent<TextMeshPro>().color = Color.white;
                break;
        }
    }


}
