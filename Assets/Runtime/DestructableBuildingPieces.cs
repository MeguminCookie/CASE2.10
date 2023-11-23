using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBuildingPieces : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject dustParticlePrefab;
    private GameObject mainCamera;
    private GameObject gamemanager;
    private CountdownTimer countdownTimer;
    private CameraShake cameraShake;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        countdownTimer = gamemanager.GetComponent<CountdownTimer>();
        cameraShake = mainCamera.GetComponent<CameraShake>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {

        }
        else
        {
            if(countdownTimer.IsGameOver() == false)
            {
                cameraShake.OnShake(0.1f, 0.2f);
            }
            
            Instantiate(dustParticlePrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
