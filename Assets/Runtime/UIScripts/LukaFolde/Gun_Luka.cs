using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Luka : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float verticalRange;
    [SerializeField] private float fireRate;
    [SerializeField] private float damage;

    [SerializeField] private EnemyManager_Luka enemyManager;
    [SerializeField] private LayerMask raycastLayerMask;

    private BoxCollider gunTrigger;
    private float nextTimeToFire;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>(); 
        gunTrigger.size = new Vector3(6f, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);   
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }

        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
