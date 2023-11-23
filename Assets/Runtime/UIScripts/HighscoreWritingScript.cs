using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreWritingScript : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI scoreOne;
    [SerializeField] private TextMeshProUGUI scoreTwo;
    [SerializeField] private TextMeshProUGUI scoreThree;

    //Names
    private string nameOne;
    private string nameTwo;
    private string nameThree;

    //Time
    private float timeOne;
    private float timeTwo;
    private float timeThree;


    void Start()
    {
        //Setting the time and names
        nameOne = PlayerPrefs.GetString("NameOne");
        timeOne = PlayerPrefs.GetInt("TimeOne");

        nameTwo = PlayerPrefs.GetString("NameTwo");
        timeTwo = PlayerPrefs.GetInt("TimeTwo");

        nameThree = PlayerPrefs.GetString("NameThree");
        timeThree = PlayerPrefs.GetInt("TimeThree");

        //Putting them on the screen
        SetHighscore(scoreOne, timeOne, nameOne);

        SetHighscore(scoreTwo, timeTwo, nameTwo);

        SetHighscore(scoreThree, timeThree, nameThree);

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
}
