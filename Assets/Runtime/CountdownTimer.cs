using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentTime;
    private int minutes;
    private int seconds;
    private float timeLeft;
    private string timeText;
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
        timeLeftText.text = TimerChange();

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TimeAdder(10f);
        }
    }

    public void TimeAdder(float timetToAdd)
    {
        timeAddedPrefab.SetText("+" + timetToAdd + "SEC");
        //Instantiate(timeAddedPrefab);
        timeLeft += timetToAdd;
    }



    private string TimerChange()
    {
        timeLeft -= Time.deltaTime;

        var minutes = timeLeft / 60;
        var seconds = timeLeft % 60;
        var miliseconds = timeLeft * 10;
        miliseconds = miliseconds % 10;
        timeText = String.Format("{0:00}:{1:00}:{2:0}", minutes, seconds, miliseconds);

        return timeText;

    }
}

