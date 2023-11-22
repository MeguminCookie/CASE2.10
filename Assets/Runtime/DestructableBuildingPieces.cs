using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBuildingPieces : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject dustParticlePrefab;
    private GameObject mainCamera;
    private CameraShake cameraShake;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
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
            cameraShake.OnShake(0.1f , 0.2f);
            Instantiate(dustParticlePrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
