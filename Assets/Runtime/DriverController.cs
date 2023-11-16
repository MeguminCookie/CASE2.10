using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (acceleration > maxSpeed)
        {
            acceleration = maxSpeed;
        }
        if (acceleration < 0)
        {
            acceleration = 0;
        }

     
       
    }

    private void MovePlayer()
    {

        
        if(Keyboard.current.upArrowKey.isPressed)
        {
            rb.velocity += transform.forward * Time.deltaTime* acceleration;
        }
        else if(Keyboard.current.downArrowKey.isPressed)
        {
            rb.velocity -= transform.forward * Time.deltaTime * acceleration;
        }
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            
            
            transform.Rotate(0, 0.1f, 0);

        }
        else if(Keyboard.current.leftArrowKey.isPressed)
        {
           
            transform.Rotate(0, -0.1f, 0);
        }

      

        if(Keyboard.current.leftArrowKey.isPressed || Keyboard.current.downArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            acceleration += Time.deltaTime * accelerationSpeed ;
        }
        else
        {
            acceleration -= Time.deltaTime * decelerationSpeed;
        }



     


    }
    

    }
