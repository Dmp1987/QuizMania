using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    string[] triviaGenres;

    // Start is called before the first frame update
    void Start()
    {
        triviaGenres = new string[] { "food_and_drink", "geography", "history", "general_knowledge", "literature", "movies", "music", "science", "society_and_culture", "sport_and_leisure" };
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
                switch (hit.transform.name)
                {
                    case "txtPlayButton" :
                        savePrefs();                        
                        break;

                    case "inputCheckbox0":                                                
                        if (PlayerPrefs.HasKey("0")) {                            
                            PlayerPrefs.DeleteKey("0");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("0", triviaGenres[0]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }                        
                        break;

                    case "inputCheckbox1":
                        if (PlayerPrefs.HasKey("1"))
                        {
                            PlayerPrefs.DeleteKey("1");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("1", triviaGenres[1]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox2":
                        if (PlayerPrefs.HasKey("3"))
                        {
                            PlayerPrefs.DeleteKey("3");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("3", triviaGenres[3]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox3":
                        if (PlayerPrefs.HasKey("3"))
                        {
                            PlayerPrefs.DeleteKey("3");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("3", triviaGenres[3]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox4":
                        if (PlayerPrefs.HasKey("4"))
                        {
                            PlayerPrefs.DeleteKey("4");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("4", triviaGenres[4]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox5":
                        if (PlayerPrefs.HasKey("5"))
                        {
                            PlayerPrefs.DeleteKey("5");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("5", triviaGenres[5]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox6":
                        if (PlayerPrefs.HasKey("6"))
                        {
                            PlayerPrefs.DeleteKey("6");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("6", triviaGenres[6]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox7":
                        if (PlayerPrefs.HasKey("7"))
                        {
                            PlayerPrefs.DeleteKey("7");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("7", triviaGenres[7]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox8":
                        if (PlayerPrefs.HasKey("8"))
                        {
                            PlayerPrefs.DeleteKey("8");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("8", triviaGenres[8]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    case "inputCheckbox9":
                        if (PlayerPrefs.HasKey("9"))
                        {
                            PlayerPrefs.DeleteKey("9");
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.white;
                        }
                        else
                        {
                            PlayerPrefs.SetString("9", triviaGenres[9]);
                            hit.transform.GetComponentInParent<TextMeshPro>().color = Color.green;
                        }
                        break;

                    default:
                        break;
                }

                Debug.Log(hit.transform.name);
            }


        }
    }
    

    private void savePrefs() 
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetString(i.ToString(), triviaGenres[i]);
        }

        SceneManager.LoadScene("TriviaScene");
    }

}

