using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int timeInSeconds;
    private int enemiesKilled;
    private bool gameActive;
    private CountdownTimer countdownTimer;

    void Start()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        gameActive = true;
    }

    void Update()
    {
        if (countdownTimer.IsGameOver() == false)
        {
            timeInSeconds = Mathf.FloorToInt(Time.time);
            SaveScore();
        }
    }

    public void UpdateKills()
    {
        enemiesKilled++;
    }

    void SaveScore()
    {
        // Save timeInSeconds and enemiesKilled to PlayerPrefs
        PlayerPrefs.SetInt("Total Time", timeInSeconds);
        PlayerPrefs.SetInt("Killed Enemies", enemiesKilled);

    }
}
