using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    int playerScore;

    void Awake() 
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void AddScore(int scoreValue)
    {
        playerScore += scoreValue;
    }

    public void DecreaseScore()
    {
        playerScore -= 10;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
