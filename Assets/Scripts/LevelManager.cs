using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoringSystem scoringSystem;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayGame()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
        scoringSystem.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void EndScreen()
    {
        SceneManager.LoadScene("End Screen");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
