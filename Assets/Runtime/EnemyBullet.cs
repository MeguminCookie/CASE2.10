using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10; // You can set this value in the Unity Editor (ja dit is van chat gpt)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the enemy has a script named EnemyHealth
            // PlayerHealth pnemyHealth = other.GetComponent<PlayerHealth>();

            /*
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                // game over sequence
            }
            */
        }
    }
}
