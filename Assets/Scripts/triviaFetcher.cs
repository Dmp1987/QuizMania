using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class triviaFetcher : MonoBehaviour
{
    public int gameLength;
    private int round = -1;
    public bool isListReady = false;
    List<triviaQuestion> questionList = new List<triviaQuestion>();

    private void Start()
    {
        generateQuestionList();
        //translateQuestions("my name is daniel");
    }
    
    public triviaQuestion getSpecificQuestion(int round) 
    {
        return questionList[round];
    }

    public triviaQuestion getNextQuestion() 
    {
        //Puhhaaa grimgrim, lav noget ordentligt game logik 
        if (round==questionList.Count-1)
        {
            Debug.LogWarning("Generating new questions!");
            generateQuestionList();
            round = -1;
        }

        round++;
        return questionList[round];        
    }

    public void generateQuestionList()
    {
        //string URL = "https://trivia.willfry.co.uk/api/questions?categories=general_knowledge,movies,music&limit=10";
        //String builder, get playerPrefs and set all genres
        string URL = "https://trivia.willfry.co.uk/api/questions?categories=" + stringifyPlayerPrefs();



        StartCoroutine(ProcessRequest(URL));

        IEnumerator ProcessRequest(string uri)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    questionList = JsonConvert.DeserializeObject<List<triviaQuestion>>(request.downloadHandler.text);
                    isListReady = true;
                }
            }            
        }
        
    }

    private string stringifyPlayerPrefs()
    {
        string genres = "";

        for (int i = 0; i < 9; i++)
        {
            genres += PlayerPrefs.GetString(i.ToString()) + ",";
        }

        return genres;
    }

    private void translateQuestions(string txtTrans) 
    {
        string URL = "https://deep-translate1.p.rapidapi.com/language/translate/v2";
        string textToTranslate = "{\r\"q\": \"Hello World!\",\r\"source\": \"en\",\r\"target\": \"es\"\r}"; 
        //string textToTranslate = "q" +":"+"Hello World!"+","+"source"+":"+"en"+","+"target"+":"+"es"; 
       
        StartCoroutine(ProcessTranslation(URL));

        IEnumerator ProcessTranslation(string uri)
        {
            UnityWebRequest request = UnityWebRequest.Get(uri);
            request.SetRequestHeader("content-type", "application/json");
            request.SetRequestHeader("x-rapidapi-key", "e0eb241ba1msh9eaee5094dc1639p11904cjsn3e0617f6d631");
            request.SetRequestHeader("x-rapidapi-host", "deep-translate1.p.rapidapi.com");
            request.SetRequestHeader("application/json", textToTranslate); 

            using (request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    //questionList = JsonConvert.DeserializeObject<List<triviaQuestion>>(request.downloadHandler.text);   
                    Debug.Log(request.downloadHandler.text);
                }
            }
        }

        /*
        StartCoroutine(SendRequest());

        IEnumerator SendRequest()
        {
            Uri uri = new Uri("https://nlp-translation.p.rapidapi.com/v1/jsontranslate"); // Uri is a class in the System namespace, pay attention to reference the namespace
            UnityWebRequest uwr = new UnityWebRequest(uri);        // Create an object UnityWebRequest
            uwr.timeout = 5;
            yield return uwr.SendWebRequest();                     // Wait returns the requested information
            if (uwr.isHttpError || uwr.isNetworkError)             // If their request fails, or network failure
            {
                Debug.LogError(uwr.error); // print the wrong reasons
            }
            else // request was successful
            {
                Debug.Log("The request was successful.");
                Debug.Log(uwr.downloadHandler.text);                
            }
        }
        */
    }


}
