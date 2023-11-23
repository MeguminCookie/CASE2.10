using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    [Header("OtherPanels")]
    [SerializeField] private GameObject newHighScore;
    [SerializeField] private GameObject addInitials;
    [SerializeField] private GameObject playAgain;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI scoreOne;
    [SerializeField] private TextMeshProUGUI scoreTwo;
    [SerializeField] private TextMeshProUGUI scoreThree;
    [SerializeField] private TextMeshProUGUI scoreCurrent;

    //Names
    private string nameOne;
    private string nameTwo;
    private string nameThree;
    private string currentName;

    //Time
    private float timeOne;
    private float timeTwo;
    private float timeThree;
    private float currentTime;

    private void Start()
    {
        nameOne = PlayerPrefs.GetString("NameOne");
        timeOne = PlayerPrefs.GetInt("TimeOne");

        nameTwo = PlayerPrefs.GetString("NameTwo");
        timeTwo = PlayerPrefs.GetInt("TimeTwo");

        nameThree = PlayerPrefs.GetString("NameThree");
        timeThree = PlayerPrefs.GetInt("TimeThree");

        currentName = "You";
        currentTime = PlayerPrefs.GetInt("Total Time");

        //SetScores
        SetHighscore(scoreOne, timeOne, nameOne);
        SetHighscore(scoreTwo, timeTwo, nameTwo);
        SetHighscore(scoreThree, timeThree, nameThree);
        SetHighscore(scoreCurrent, currentTime, currentName);

        StartCoroutine(WaitForSwitch());
    }

    private void SetHighscore(TextMeshProUGUI timeText, float currentTime, string currentName)
    {
        int secTime = 0;
        int minTime = 0;

        for (int i = 0; i < currentTime; i++)
        {
            secTime++;
            if (secTime == 60)
            {
                minTime++;
                secTime = 0;
            }
        }

        if (minTime < 10)
        {
            if (secTime < 10)
            {
                timeText.SetText($"{currentName}: 0{minTime}:0{secTime}");
            }
            else
            {
                timeText.SetText($"{currentName}: 0{minTime}:{secTime}");
            }
        }
        else
        {
            timeText.SetText($"{currentName}: {minTime}:{secTime}");
        }
    }

    private IEnumerator WaitForSwitch()
    {
        yield return new WaitForSeconds(3f);

        if (currentTime > timeThree)
        {
            newHighScore.SetActive(true);

            yield return new WaitForSeconds(3f);
            addInitials.SetActive(true);
            newHighScore.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            playAgain.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
