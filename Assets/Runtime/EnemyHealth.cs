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
    [SerializeField] private GameObject timeDmgPrefab;
    [SerializeField] private ScoreManager scoreManager;
    private GameObject rotationText;
    private GameObject countDownObject;
    private float timeAdd;
    
    private void Start()
    {
        rotationText = GameObject.FindGameObjectWithTag("TextSpawn");
        //audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        //countDownObject = GameObject.FindGameObjectWithTag("Gamemanager");
        //timer = countDownObject.GetComponent< CountdownTimer >(); 
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        timer = gamemanager.GetComponent<CountdownTimer>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    private void Update()
    {
        timeAdd = timer.GetTimeAdding();
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
        scoreManager.UpdateKills();
        timer.TimeAdder(timeAdd);
        //PlayRandomSound();
        
        AudioSource.PlayClipAtPoint(clip, enemy.transform.position);
        Debug.Log("Sound effect instantiated");
        Instantiate(timeDmgPrefab, transform.position,rotationText.transform.rotation);
        Destroy(gameObject); // Destroy the enemy GameObject
        Debug.Log("Enemy killed!");        
        Debug.Log("Time added");
    }

    
}
