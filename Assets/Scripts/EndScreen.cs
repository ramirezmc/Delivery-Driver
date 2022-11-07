using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    ScoringSystem scoringSystem;

    void Awake() 
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();    
    }

    void Update() 
    {
        scoreDisplay.text = "Your score is:\n" + scoringSystem.GetPlayerScore().ToString();   
    }
}
