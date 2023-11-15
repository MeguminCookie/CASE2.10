using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriverController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decelerationSpeed;
    private float timePassedMovement;
    [SerializeField] private GameObject driver;
    private CharacterController characterController;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if(acceleration < 0)
        {
            acceleration = 0;
        }
        
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            driver.transform.position += transform.forward* acceleration * Time.deltaTime;
            //acceleration += Time.deltaTime * accelerationSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            driver.transform.position -= transform.forward * acceleration * Time.deltaTime; ;
            //acceleration += Time.deltaTime * accelerationSpeed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            driver.transform.position -= transform.right * acceleration * Time.deltaTime;
            //acceleration += Time.deltaTime * accelerationSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            driver.transform.position += transform.right * acceleration * Time.deltaTime;
            //acceleration += Time.deltaTime * accelerationSpeed;
        }
        else
        {
            //acceleration -= Time.deltaTime *decelerationSpeed;
        }
        

           // driver.transform.position = driver.transform.position.normalized * acceleration;
        
        characterController.Move(driver.transform.position * Time.deltaTime);


        if(Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.qKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            acceleration += Time.deltaTime * accelerationSpeed;
        }
        else
        {
            acceleration -= Time.deltaTime * decelerationSpeed;
        }

    }
  

}
