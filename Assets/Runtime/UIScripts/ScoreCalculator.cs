using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private string nameOne;
    private string nameTwo;
    private string nameThree;

    private int timeOne;
    private int timeTwo;
    private int timeThree;

    void Start()
    {
        nameOne = PlayerPrefs.GetString("NameOne");
        timeOne = PlayerPrefs.GetInt("TimeOne");

        nameTwo = PlayerPrefs.GetString("NameTwo");
        timeTwo = PlayerPrefs.GetInt("TimeTwo");

        nameThree = PlayerPrefs.GetString("NameThree");
        timeThree = PlayerPrefs.GetInt("TimeThree");
    }

    public void IsScoreHigher(string currentName, int currentTime)
    {
        if (currentTime > timeThree)
        {
            if (currentTime > timeTwo)
            {
                if (currentTime > timeOne)
                {
                    PlayerPrefs.SetString("NameOne", currentName);
                    PlayerPrefs.SetInt("TimeOne", currentTime);

                    PlayerPrefs.SetString("NameTwo", nameOne);
                    PlayerPrefs.SetInt("TimeTwo", timeOne);

                    PlayerPrefs.SetString("NameThree", nameTwo);
                    PlayerPrefs.SetInt("TimeThree", timeTwo);
                }
                else
                {
                    PlayerPrefs.SetString("NameTwo", currentName);
                    PlayerPrefs.SetInt("TimeTwo", currentTime);

                    PlayerPrefs.SetString("NameThree", nameTwo);
                    PlayerPrefs.SetInt("TimeThree", timeTwo);
                }
            }
            else
            {
                PlayerPrefs.SetString("NameThree", currentName);
                PlayerPrefs.SetInt("TimeThree", currentTime);
            }
        }
        else
        {
            Debug.Log("No new score");
        }
    }

}
