using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deleter : MonoBehaviour
{

    private float time;
    private GameObject mainCamera;
    private CameraShake cameraShake;
    private GameObject gamemanger;
    private CountdownTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        gamemanger = GameObject.FindGameObjectWithTag("GameManager");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        timer = gamemanger.GetComponent<CountdownTimer>();
        cameraShake = mainCamera.GetComponent<CameraShake>();
        if(timer.IsGameOver() == false)
        {
            cameraShake.OnShake(0.3f, 0.2f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 3)
        {
            Destroy(gameObject);
        }
    }
}
