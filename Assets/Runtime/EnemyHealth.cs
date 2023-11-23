using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField] private float timeToAdd;
    public int maxHealth = 100; // You can set this value in the Unity Editor

    public int currentHealth;
    private CountdownTimer timer;
    [SerializeField] private GameObject gamemanager;
    public AudioClip clip;
    [SerializeField] private GameObject enemy;
    //private GameObject countDownObject;
    //private CountdownTimer timer;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        //countDownObject = GameObject.FindGameObjectWithTag("Gamemanager");
        //timer = countDownObject.GetComponent< CountdownTimer >(); 
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        timer = gamemanager.GetComponent<CountdownTimer>();
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            //timer.TimeAdder(timeToAdd);
            Die();
        }
    }

    public int GetHealth()
    {
        return currentHealth;

    }
    /*
    void PlayRandomSound()
    {
        if (soundEffects.Length > 0)
        {
            int randomIndex = Random.Range(0, soundEffects.Length);
            audioSource.PlayOneShot(soundEffects[randomIndex]);
        }
        else
        {
            Debug.LogError("No sound effects available!");
        }
    }
    */
    public void Die()
    {
        // Handle enemy death (e.g., play death animation, spawn particles, etc.)

        timer.TimeAdder(10f);
        //PlayRandomSound();
        
        AudioSource.PlayClipAtPoint(clip, enemy.transform.position);
        Debug.Log("Sound effect instantiated");
        Destroy(gameObject); // Destroy the enemy GameObject
        Debug.Log("Enemy killed!");        
        Debug.Log("Time added");
    }

    
}
