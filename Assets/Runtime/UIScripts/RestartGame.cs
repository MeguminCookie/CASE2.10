using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject yes;
    [SerializeField] private GameObject no;

    private bool isOnYes = true;
    private bool isOnNo = false;

    private void Update()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (isOnYes)
                StartCoroutine(GoToNo());
            if (isOnNo)
                StartCoroutine(GoToYes());
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (isOnYes)
                StartCoroutine(GoToNo());
            if (isOnNo)
                StartCoroutine(GoToYes());
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (isOnYes)
            {
                SceneManager.LoadScene(1);
            }
            if (isOnNo)
            {
                SceneManager.LoadScene(0);
            }
        }
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
}
