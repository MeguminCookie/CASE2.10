using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNU : MonoBehaviour
{
    /*
    public float smallDamage = 1f;
    public float fullDamage = 2f;
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float nextTimeToFire;
    public float alertRadius = 20f;
    public int maxAmmo = 100;
    private int ammo;
    public int startAmmo;

    
    // Layermasks
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;
    */

    // Start is called before the first frame update
    void Start()
    {
        /*
        ammo = startAmmo;
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        UIManager.Instance.UpdateAmmo(ammo);
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
        */
    }
    /*
    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, alertRadius, enemyLayerMask); 

        // Alert enemies
        foreach(var enemyCollider in enemyColliders)
        {
            //enemyCollider.GetComponent<EnemyAwareness>().isActive = true;
        }


        // Gunshot sound
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        // Damage enemies
        foreach(var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, dir, out hit, range + 1.5f, raycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if(dist > range * 0.5f)
                    {
                    // Apply damage
                    enemy.TakeDamage(smallDamage);

                    Debug.DrawRay(transform.position, dir, Color.green);
                    //Debug.Break();
                    }
                    else
                    {
                    // Apply damage
                    enemy.TakeDamage(fullDamage);

                    Debug.DrawRay(transform.position, dir, Color.green);
                    //Debug.Break();                        
                    }

                }
            }


        }

        // Reset timer
        nextTimeToFire = Time.time + fireRate;

        // Reduce ammo
        ammo--;
        UIManager.Instance.UpdateAmmo(ammo);
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }

        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        UIManager.Instance.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }  
    }
    */
}
