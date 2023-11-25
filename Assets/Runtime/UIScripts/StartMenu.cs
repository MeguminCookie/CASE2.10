using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("OtherPanels")]
    [SerializeField] private GameObject highscorePanel;
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Buttons")]
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;

    private bool isOnStart;
    private bool isOnHighScore;
    private bool isOnHowToPlay;
    private bool isOnCredits;

    void Start()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);   

        isOnStart = true;
        isOnHighScore =  false;
        isOnHowToPlay = false;
        isOnCredits = false;
    }

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if(isOnStart)
            {
                Debug.Log("Start Game");
                SceneManager.LoadScene(1);
            }
            if (isOnHighScore)
            {
                Debug.Log("Show Highscore");
                highscorePanel.SetActive(true);
                gameObject.SetActive(false);
                 
            }
            if (isOnHowToPlay)
            {
                Debug.Log("Show How to Play");
                howToPlayPanel.SetActive(true);
                gameObject.SetActive(false);
            }
            if (isOnCredits)
            {
                Debug.Log("Show Credits");
                creditsPanel.SetActive(true);
                gameObject.SetActive(false);
                 
            }
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (isOnStart)
                StartCoroutine(SetToHighscore());
            if (isOnHighScore)
                StartCoroutine(SetToHowToPlay());
            if (isOnHowToPlay)
                StartCoroutine(SetToCedits());
            if (isOnCredits)
                StartCoroutine(SetToStart());
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (isOnStart)
                StartCoroutine(SetToCedits());
            if (isOnHighScore)
                StartCoroutine(SetToStart());
            if (isOnHowToPlay)
                StartCoroutine(SetToHighscore());
            if (isOnCredits)
                StartCoroutine(SetToHowToPlay());
        }
    }

    private IEnumerator SetToStart()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnStart = true;
        isOnHighScore = false;
        isOnHowToPlay = false;
        isOnCredits = false;
    }
    
    private IEnumerator SetToHighscore()
    {
        button1.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);
        button4.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnStart = false;
        isOnHighScore = true;
        isOnHowToPlay = false;
        isOnCredits = false;
    }

    private IEnumerator SetToCedits()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(true);

        yield return new WaitForEndOfFrame();

        isOnStart = false;
        isOnHighScore = false;
        isOnHowToPlay = false;
        isOnCredits = true;
    }

    private IEnumerator SetToHowToPlay()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
        button4.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnStart = false;
        isOnHighScore = false;
        isOnHowToPlay = true;
        isOnCredits = false;
    }
}
