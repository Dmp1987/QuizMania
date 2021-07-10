using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System;

[Serializable]
public struct triviaQuestion 
{                    
        public string category { get; set; }
        public string correctAnswer { get; set; }
        public List<string> incorrectAnswers { get; set; }
        public string question { get; set; }
        public string type { get; set; }
}