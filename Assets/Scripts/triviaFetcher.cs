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
        string URL = "https://trivia.willfry.co.uk/api/questions?categories=general_knowledge,movies,music&limit=10";

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

    private void translateQuestions() 
    {
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
