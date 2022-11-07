using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 200;
    [SerializeField]float moveSpeed = 50;
    [SerializeField]float slowSpeed = 15;
    [SerializeField]float boostSpeed = 10;
    LevelManager levelManager;
    ScoringSystem scoringSystem;
    UIDisplay timer;
    int playerScore;
    void Awake() 
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
        levelManager = FindObjectOfType<LevelManager>();
        timer = FindObjectOfType<UIDisplay>();
    }
    void Update()
    {
        playerScore = scoringSystem.GetPlayerScore();
        PlayerMovement();
    }
    void PlayerMovement()
    {
        bool timerState = timer.GetTimerState();
        if(timerState)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);
        }
        else
        {
            StartCoroutine (GoToEndScreen());
            return;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            StartCoroutine (Boosted());
        }
    }

    IEnumerator Boosted()
    {
        moveSpeed += boostSpeed;
        yield return new WaitForSecondsRealtime(3);
        moveSpeed -= boostSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        StartCoroutine (SlowedState());
        if (playerScore > 0)
        {
            StartCoroutine (BumpedIntoObjects());
        }
    }
    IEnumerator BumpedIntoObjects()
    {
        scoringSystem.DecreaseScore();
        yield return new WaitForSecondsRealtime(1);
    }

    IEnumerator SlowedState()
    {
        moveSpeed -= slowSpeed;
        yield return new WaitForSecondsRealtime (0.7f);
        moveSpeed += slowSpeed;
    }

    IEnumerator GoToEndScreen()
    {
        yield return new WaitForSeconds(2);
        levelManager.EndScreen();
    }
}
