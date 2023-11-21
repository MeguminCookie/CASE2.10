using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [Header("OtherPanels")]
    [SerializeField] private GameObject highscorePanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Buttons")]
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    private bool isOnStart;
    private bool isOnHighScore;
    private bool isOnCredits;

    void Start()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);

        isOnStart = true;
        isOnHighScore =  false;
        isOnCredits = false;
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            if(isOnStart)
            {
                Debug.Log("Start Game");
                //SceneManager.LoadScene(1);
            }
            if (isOnHighScore)
            {
                Debug.Log("Show Highscore");
                highscorePanel.SetActive(true);
                gameObject.SetActive(false);
                 
            }
            if (isOnCredits)
            {
                Debug.Log("Show Credits");
                creditsPanel.SetActive(true);
                gameObject.SetActive(false);
                 
            }
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (isOnStart)
                StartCoroutine(SetToHighscore());
            if (isOnHighScore)
                StartCoroutine(SetToCedits());
            if (isOnCredits)
                StartCoroutine(SetToStart());
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (isOnStart)
                StartCoroutine(SetToCedits());
            if (isOnHighScore)
                StartCoroutine(SetToStart());
            if (isOnCredits)
                StartCoroutine(SetToHighscore());
        }
    }

    private IEnumerator SetToStart()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnStart = true;
        isOnHighScore = false;
        isOnCredits = false;
    }
    
    private IEnumerator SetToHighscore()
    {
        button1.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnStart = false;
        isOnHighScore = true;
        isOnCredits = false;
    }

    private IEnumerator SetToCedits()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);

        yield return new WaitForEndOfFrame();

        isOnStart = false;
        isOnHighScore = false;
        isOnCredits = true;
    }
}
