using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HighScoreMenu : MonoBehaviour
{
    [Header("StartPanel")]
    [SerializeField] private GameObject startPanel;

    [Header("Buttons")]
    [SerializeField] private GameObject highscore;
    [SerializeField] private GameObject back;

    private bool isOnHighscore;
    private bool isOnBack;

    void Start()
    {
        highscore.SetActive(true);
        back.SetActive(false);

        isOnHighscore = true;
        isOnBack = false;
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            if (isOnBack)
            {
                highscore.SetActive(true);
                back.SetActive(false);

                isOnHighscore = true;
                isOnBack = false;

                startPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        {
            if (isOnBack)
                StartCoroutine(SetToHighscore());
            if (isOnHighscore)
                StartCoroutine(SetToBack());
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (isOnBack)
                StartCoroutine(SetToHighscore());
            if (isOnHighscore)
                StartCoroutine(SetToBack());
        }
    }

    private IEnumerator SetToHighscore()
    {
        highscore.SetActive(true);
        back.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnHighscore = true;
        isOnBack = false;
    }

    private IEnumerator SetToBack()
    {
        highscore.SetActive(false);
        back.SetActive(true);

        yield return new WaitForEndOfFrame();

        isOnHighscore = false;
        isOnBack = true;
    }
}
