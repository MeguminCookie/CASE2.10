using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float timeToAdd;
    public int maxHealth = 100; // You can set this value in the Unity Editor

    public int currentHealth;

    //private GameObject countDownObject;
    //private CountdownTimer timer;

    private void Start()
    {
        currentHealth = maxHealth;
        //countDownObject = GameObject.FindGameObjectWithTag("Gamemanager");
        //timer = countDownObject.GetComponent< CountdownTimer >(); 
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

    private void Die()
    {
        // Handle enemy death (e.g., play death animation, spawn particles, etc.)
        //Destroy(gameObject); // Destroy the enemy GameObject
        Debug.Log("Enemy killed!");
    }
}
