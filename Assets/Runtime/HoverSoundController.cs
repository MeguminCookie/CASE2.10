using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSoundController : MonoBehaviour
{
    public AudioSource hoverSound;
    public float baseVolume = 0.2f; // Minimum volume
    public float maxVolume = 0.6f;  // Maximum volume
    public float accelerationThreshold = 0.1f;
    public float volumeIncreaseFactor = 0.2f;

    private Rigidbody tankRigidbody;
    private Vector3 previousVelocity;

    private void Start()
    {
        // Make sure the AudioSource is assigned
        if (hoverSound == null)
        {
            hoverSound = GetComponent<AudioSource>();
        }

        // Get the Rigidbody component
        tankRigidbody = GetComponent<Rigidbody>();

        // Set initial volume
        hoverSound.volume = baseVolume;

        // Initialize previousVelocity
        previousVelocity = tankRigidbody.velocity;
    }

    private void Update()
    {
        // Check if the tank is moving
        bool isMoving = IsMoving();

        // Check if the tank is decelerating
        bool isDecelerating = IsDecelerating();

        // Adjust volume based on movement and other events
        if (isMoving || isDecelerating)
        {
            float newVolume = hoverSound.volume + volumeIncreaseFactor * Time.deltaTime;
            hoverSound.volume = Mathf.Clamp(newVolume, baseVolume, maxVolume);
        }
        else
        {
            // Ensure that the volume doesn't drop below the minimum value
            float newVolume = hoverSound.volume - volumeIncreaseFactor * Time.deltaTime;
            hoverSound.volume = Mathf.Clamp(newVolume, baseVolume, maxVolume);
        }
    }

    private bool IsMoving()
    {
        // Use the magnitude of the velocity to check if the tank is moving
        return tankRigidbody.velocity.magnitude > accelerationThreshold;
    }

    private bool IsDecelerating()
    {
        // Calculate the acceleration based on the change in velocity over time
        Vector3 currentVelocity = tankRigidbody.velocity;
        Vector3 acceleration = (currentVelocity - previousVelocity) / Time.deltaTime;

        // Check if the acceleration is negative, indicating deceleration
        bool isDecelerating = Vector3.Dot(currentVelocity, acceleration) < 0;

        // Update previousVelocity for the next frame
        previousVelocity = currentVelocity;

        return isDecelerating;
    }

    // You can call this method from other scripts or events to simulate being bumped by an enemy
    public void SimulateBump()
    {
        // Increase the volume when bumped
        hoverSound.volume = Mathf.Clamp01(hoverSound.volume + volumeIncreaseFactor);
    }
}