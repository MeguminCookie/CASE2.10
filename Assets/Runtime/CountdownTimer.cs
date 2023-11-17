using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTime;
    private int minutes;
    private int seconds;
    private float timeLeft;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private TextMeshProUGUI timeAddedPrefab;
    private float timeAdded;
    void Start()
    {
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        TimerChange();

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TimeAdder(10f);
        }
    }

    public void TimeAdder(float timetToAdd)
    {
        timeAddedPrefab.SetText("+" + timetToAdd + "SEC");
        Instantiate(timeAddedPrefab);
        timeLeft += timetToAdd;
    }

    private void TimerChange()
    {
        seconds = Convert.ToInt32(timeLeft);
        
        timeLeft -= Time.deltaTime;
        if(timeLeft >= 60)
        {
            timeLeft -= 60;
            minutes += 1;
        }
        if(timeLeft < 0 && minutes ==0)
        {
            Debug.Log("GameOver");
        }
        else if(timeLeft <0)
        {
            timeLeft = 60;
            minutes -= 1;
        }

        if(seconds >= 10)
        {
            timeLeftText.SetText(minutes + ":" + seconds);
        }
        else
        {
            timeLeftText.SetText("0" + minutes + ":0"  + seconds);
        }

    }
}
