using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeLeft;
    private string timeText;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private TextMeshProUGUI timeAddedPrefab;
    [SerializeField] private float timeColorChange30Sec;
    [SerializeField] private float timeColorChange15Sec;
    [SerializeField] private Image blackBackground;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private Transform locationForText;
    private bool isGameOver;
    private float timeAdded;
    private bool colorChanged;
    void Start()
    {
        colorChanged = false;
        isGameOver = false;
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
        if(colorChanged == false && timeLeft <= 30)
        {
            StartCoroutine(TimerColorChange(timeColorChange30Sec,timeColorChange15Sec));
        }

        if(timeLeft <= 0 && isGameOver!)
        {
            StartCoroutine(GameOver());
        }
    }

    public void TimeAdder(float timetToAdd)
    {
        timeAddedPrefab.SetText("+" + timetToAdd + "SEC");
        Instantiate(timeAddedPrefab);
        timeLeft += timetToAdd;
    }



    private string TimerChange()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft > 0) { 
        }
        var minutes = Mathf.Floor(timeLeft / 60);
        var seconds = Mathf.Floor(timeLeft % 60);
        //var miliseconds = timeLeft * 10;
        //miliseconds = miliseconds % 10;
        if(timeLeft > 0)
        {
            timeText = String.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeText = "00:00";
        }

        return timeText;

    }

    private IEnumerator TimerColorChange(float colorChangeCooldown30Sec, float colorChangeCooldown15Sec)
    {
        if(timeLeft <= 30 && timeLeft >15)
        {
            timeLeftText.color = Color.red;
            colorChanged = true;
            yield return new WaitForSeconds(colorChangeCooldown30Sec);
            timeLeftText.color = Color.white;
            yield return new WaitForSeconds(colorChangeCooldown30Sec);
            colorChanged = false;

        }
        else if(timeLeft <= 15 && timeLeft >0)
        {

            timeLeftText.color = Color.red;
            colorChanged = true;
            yield return new WaitForSeconds(colorChangeCooldown15Sec);
            timeLeftText.color = Color.white;
            yield return new WaitForSeconds(colorChangeCooldown15Sec);
            colorChanged = false;

        }
        else
        {
            timeLeftText.color = Color.red;
            colorChanged = true;
            yield return new WaitForEndOfFrame();
        }
       
    }

    private IEnumerator GameOver()
    {
        isGameOver = true;
        blackBackground.DOFade(1, 2.5f);
        yield return new WaitForSeconds(2.5f);
        outOfTimeText.transform.DOMoveY(540 , 1.2f);
        yield return new WaitForSeconds(3.6f);
        outOfTimeText.transform.DOMoveY(-540, 1.2f);
        yield return new WaitForSeconds(1f);
        // Verander naar de score scene
        // SceneManager.LoadScene();
    }
    
    
}

