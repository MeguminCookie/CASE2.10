using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnterNameMenu : MonoBehaviour
{
    [Header("Initial Switch")]
    [SerializeField] private bool isInitial1;
    [SerializeField] private bool isInitial2;
    [SerializeField] private bool isContinue;
    [SerializeField] private TextMeshProUGUI initial1Text;
    [SerializeField] private TextMeshProUGUI initial2Text;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private GameObject borderInitial1;
    [SerializeField] private GameObject borderInitial2;

    [Header("Keeping name")]
    [SerializeField] private GameObject areYouSureScreen;
    [SerializeField] private GameObject yes;
    [SerializeField] private GameObject no;
    [SerializeField] private ScoreCalculator calculator;

    [SerializeField] private GameObject restartGamePanel;

    //Intitial Switch
    private int currentLetterInitial1;
    private int currentLetterInitial2;
    private string initial1Letter;
    private string initial2Letter;

    //KeepingName
    private bool areYouSure;
    private bool isOnYes;
    private bool isOnNo;
    private bool wait;

    // Start is called before the first frame update
    void Start()
    {
        currentLetterInitial1 = 1;
        currentLetterInitial2 = 1;
        isInitial1 = true;
        isInitial2 = false;
        isContinue = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!areYouSure)
        {
            SwitchingButtons();
            IndicateButton();
            ChangeLettersInitials1();
            ChangeLettersInitials2();
            initial1Text.text = initial1Letter;
            initial2Text.text = initial2Letter;
        }

        if (Keyboard.current.fKey.wasPressedThisFrame && !areYouSure)
        {
            areYouSure = true;
            isOnYes = true;
            isOnNo = false;
            wait = true;
            StartCoroutine(Unwait());

            areYouSureScreen.SetActive(true);
            yes.SetActive(true);
            no.SetActive(false);
        }

        if (Keyboard.current.fKey.wasPressedThisFrame && areYouSure && !wait)
        {
            if (isOnYes)
            {
                //KeepNames, go to next screen
                PlayerPrefs.SetString("PlayerNames", $"{initial1Letter}&{initial2Letter}");

                calculator.IsScoreHigher(PlayerPrefs.GetString("PlayerNames"), PlayerPrefs.GetInt("Total Time"));

                restartGamePanel.SetActive(true);
                gameObject.SetActive(false);
            }
            if (isOnNo)
            {
                areYouSure = false;
                areYouSureScreen.SetActive(false);
            }
        }

        if (Keyboard.current.dKey.wasPressedThisFrame && areYouSure)
        {
            if (isOnYes)
                StartCoroutine(GoToNo());
            if (isOnNo)
                StartCoroutine(GoToYes());
        }

        if (Keyboard.current.aKey.wasPressedThisFrame && areYouSure)
        {
            if (isOnYes)
                StartCoroutine(GoToNo());
            if (isOnNo)
                StartCoroutine(GoToYes());
        }
    }

    private IEnumerator Unwait()
    {
        yield return new WaitForEndOfFrame();

        wait = false;
    }

    private IEnumerator GoToYes()
    {
        yes.SetActive(true);
        no.SetActive(false);

        yield return new WaitForEndOfFrame();

        isOnYes = true;
        isOnNo = false;
    }

    private IEnumerator GoToNo()
    {
        yes.SetActive(false);
        no.SetActive(true);

        yield return new WaitForEndOfFrame();

        isOnYes = false;
        isOnNo = true;
    }

    private void IndicateButton()
    {
        if (isInitial1)
        {
            borderInitial1.SetActive(true);
        }
        else
        {
            borderInitial1.SetActive(false);
        }
        if (isInitial2)
        {
            borderInitial2.SetActive(true);
        }
        else
        {
            borderInitial2.SetActive(false);
        }

    }
    private void SwitchingButtons()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (isInitial1)
            {
                isInitial1 = false;
                isInitial2 = true;
            }
            else if (isInitial2)
            {
                isInitial2 = false;
                isContinue = true;
            }
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (isContinue)
            {
                isContinue = false;
                isInitial2 = true;
            }
            else if (isInitial2)
            {
                isInitial2 = false;
                isInitial1 = true;
            }
        }
    }

    private void ChangeLettersInitials1()
    {
        if (isInitial1 && Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (currentLetterInitial1 < 26)
            {
                currentLetterInitial1 += 1;
            }
            else
            {
                currentLetterInitial1 = 1;
            }

        }
        else if (isInitial1 && Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (currentLetterInitial1 > 1)
            {
                currentLetterInitial1 -= 1;
            }
            else
            {
                currentLetterInitial1 = 26;
            }

        }


        switch (currentLetterInitial1)
        {
            case 1:
                initial1Letter = "A";
                return;
            case 2:
                initial1Letter = "B";
                return;
            case 3:
                initial1Letter = "C";
                return;
            case 4:
                initial1Letter = "D";
                return;
            case 5:
                initial1Letter = "E";
                return;
            case 6:
                initial1Letter = "F";
                return;
            case 7:
                initial1Letter = "G";
                return;
            case 8:
                initial1Letter = "H";
                return;
            case 9:
                initial1Letter = "I";
                return;
            case 10:
                initial1Letter = "J";
                return;
            case 11:
                initial1Letter = "K";
                return;
            case 12:
                initial1Letter = "L";
                return;
            case 13:
                initial1Letter = "M";
                return;
            case 14:
                initial1Letter = "N";
                return;
            case 15:
                initial1Letter = "O";
                return;
            case 16:
                initial1Letter = "P";
                return;

            case 17:
                initial1Letter = "Q";
                return;
            case 18:
                initial1Letter = "R";
                return;
            case 19:
                initial1Letter = "S";
                return;
            case 20:
                initial1Letter = "T";
                return;
            case 21:
                initial1Letter = "U";
                return;
            case 22:
                initial1Letter = "V";
                return;

            case 23:
                initial1Letter = "W";
                return;
            case 24:
                initial1Letter = "X";
                return;
            case 25:
                initial1Letter = "Y";
                return;
            case 26:
                initial1Letter = "Z";
                return;
        }





    }
    private void ChangeLettersInitials2()
    {
        if (isInitial2 && Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (currentLetterInitial2 < 26)
            {
                currentLetterInitial2 += 1;
            }
            else
            {
                currentLetterInitial2 = 1;
            }

        }
        else if (isInitial2 && Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (currentLetterInitial2 > 1)
            {
                currentLetterInitial2 -= 1;
            }
            else
            {
                currentLetterInitial2 = 26;
            }

        }
        switch (currentLetterInitial2)
        {
            case 1:
                initial2Letter = "A";
                return;
            case 2:
                initial2Letter = "B";
                return;
            case 3:
                initial2Letter = "C";
                return;
            case 4:
                initial2Letter = "D";
                return;
            case 5:
                initial2Letter = "E";
                return;
            case 6:
                initial2Letter = "F";
                return;
            case 7:
                initial2Letter = "G";
                return;
            case 8:
                initial2Letter = "H";
                return;
            case 9:
                initial2Letter = "I";
                return;
            case 10:
                initial2Letter = "J";
                return;
            case 11:
                initial2Letter = "K";
                return;
            case 12:
                initial2Letter = "L";
                return;
            case 13:
                initial2Letter = "M";
                return;
            case 14:
                initial2Letter = "N";
                return;
            case 15:
                initial2Letter = "O";
                return;
            case 16:
                initial2Letter = "P";
                return;

            case 17:
                initial2Letter = "Q";
                return;
            case 18:
                initial2Letter = "R";
                return;
            case 19:
                initial2Letter = "S";
                return;
            case 20:
                initial2Letter = "T";
                return;
            case 21:
                initial2Letter = "U";
                return;
            case 22:
                initial2Letter = "V";
                return;

            case 23:
                initial2Letter = "W";
                return;
            case 24:
                initial2Letter = "X";
                return;
            case 25:
                initial2Letter = "Y";
                return;
            case 26:
                initial2Letter = "Z";
                return;
        }
    }
}
