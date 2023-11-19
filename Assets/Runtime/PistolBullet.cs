using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PistolBullet : MonoBehaviour
{
    private int damage = 10; // You can set this value in the Unity Editor (ja dit is van chat gpt)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Assuming the enemy has a script named EnemyHealth
         EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();  
         enemyHealth.TakeDamage(damage);
         Destroy(gameObject); // Destroy the bullet upon hitting the enemy
            
        }
    }
}
