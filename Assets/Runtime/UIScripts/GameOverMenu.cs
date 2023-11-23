using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private float timeBetweenCounting = 0.01f;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private GameObject showHighScore;

    [SerializeField] private int tempTimer;
    [SerializeField] private int tempKills;

    private float totalTime;
    private float totalEnemiesKilled;

    private int secTime, minTime, enemyCount;



    void Start()
    {
        totalTime = PlayerPrefs.GetInt("Total Time");
        totalEnemiesKilled = PlayerPrefs.GetInt("Killed Enemies");

        totalTime = tempTimer;
        totalEnemiesKilled = tempKills;

        StartCoroutine(CountUpTimer()); 
        StartCoroutine(CountUpKills());
    }

    private void Update()
    {
        if (minTime < 10)
        {
            if (secTime < 10)
            {
                timeText.SetText($"0{minTime}:0{secTime}");
            }
            else
            {
                timeText.SetText($"0{minTime}:{secTime}");
            }
        }
        else
        {
            timeText.SetText($"{minTime}:{secTime}");
        }

        if (enemyCount > 9)
        {
            if (enemyCount > 99)
            {
                if (enemyCount > 999)
                {
                    if (enemyCount > 9999)
                    {
                        killsText.SetText($"{enemyCount}");
                    }
                    else
                    {
                        killsText.SetText($"0{enemyCount}");
                    }
                }
                else
                {
                    killsText.SetText($"00{enemyCount}");
                }
            }
            else
            {
                killsText.SetText($"000{enemyCount}");
            }
        }
        else
        {
            killsText.SetText($"0000{enemyCount}");
        }
    }

    private IEnumerator CountUpTimer()
    {
        for (int i = 0; i < totalTime; i++)
        {
            secTime++;
            if (secTime == 60)
            {
                minTime++;
                secTime = 0;
            }

            yield return new WaitForSeconds(timeBetweenCounting);
        }
    }

    private IEnumerator CountUpKills()
    {
        for (int i = 0; i < totalEnemiesKilled; i++)
        {
            enemyCount++;
            yield return new WaitForSeconds(timeBetweenCounting);
        }

        yield return new WaitForSeconds(12f);
        showHighScore.SetActive(true);
        gameObject.SetActive(false);
    }
}
