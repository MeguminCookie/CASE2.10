using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    [SerializeField] private GameObject destroyedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Instantiate(destroyedObject,transform.position, quaternion.Euler(0,transform.rotation.y,0));
            Destroy(gameObject);

        }
    }
}
