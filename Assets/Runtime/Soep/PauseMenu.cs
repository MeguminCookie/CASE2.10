using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame && isPaused == false)
        {
            Debug.Log("Hi0" + isPaused);
            isPaused=true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(Keyboard.current.enterKey.wasPressedThisFrame && isPaused == true )
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if(Keyboard.current.leftBracketKey.wasPressedThisFrame && isPaused == true )
        {
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);

        }




    }
}
