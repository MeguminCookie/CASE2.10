using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{

    private float time;
    private GameObject mainCamera;
    private CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraShake = mainCamera.GetComponent<CameraShake>();
        cameraShake.OnShake(0.3f, 0.2f);
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
