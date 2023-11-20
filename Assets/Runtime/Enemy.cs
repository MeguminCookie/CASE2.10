using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth;
    public EnemyManager enemyManager;

    public GameObject hitEffect;
    //private PlayerHealth playerHealth;

    public bool isHallucination = false;

    public int hallucinationDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = FindObjectOfType<PlayerHealth>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            
                enemyManager.RemoveEnemy(this);
                Destroy(gameObject);


        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }
}
