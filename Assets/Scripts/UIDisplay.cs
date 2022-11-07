using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] float timer;
    bool TimerOn;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoringSystem scoringSystem;
    
    void Start()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
        TimerOn = true;
    }

    void Update()
    {
        TimerCountdown();
        scoreText.text = scoringSystem.GetPlayerScore().ToString("000000");
    }

    void TimerCountdown()
    {
        if (TimerOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerText(timer);
            }
            else
            {
                TimerOn = false;
                timer = 0;
            }
        }
    }

    void UpdateTimerText (float currentTime)
    {
        currentTime += 1;

        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", min, sec);       
    }

    public bool GetTimerState()
    {
        return TimerOn;
    }
}
