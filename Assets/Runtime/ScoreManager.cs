using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float timeInSeconds;
    private int enemiesKilled;
    private bool gameActive;
    private CountdownTimer countdownTimer;

    void Start()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        gameActive = true;

        timeInSeconds = 0;
        enemiesKilled = 0;

        PlayerPrefs.SetInt("Total Time", 0);
        PlayerPrefs.SetInt("Killed Enemies", enemiesKilled);
    }

    void Update()
    {
        if (countdownTimer.IsGameOver() == false)
        {
            timeInSeconds += Time.deltaTime;
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
        PlayerPrefs.SetInt("Total Time", Mathf.FloorToInt(timeInSeconds));
        PlayerPrefs.SetInt("Killed Enemies", enemiesKilled);

    }
}
