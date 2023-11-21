using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBuildingPieces : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject dustParticlePrefab;

    void Start()
    {
        
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
            Instantiate(dustParticlePrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
