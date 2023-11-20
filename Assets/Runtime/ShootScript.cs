using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float smallDamage = 1f;
    public float fullDamage = 2f;
    public float range = 150f;
    public float verticalRange = 20f;
    public float fireRate = 1f;
    public float nextTimeToFire;
    
    


    // Layermasks
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    private BoxCollider leftGunTrigger;
    private BoxCollider rightGunTrigger;

    public EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        leftGunTrigger = GetComponent<BoxCollider>();
        rightGunTrigger = GetComponent<BoxCollider>();

        leftGunTrigger.size = new Vector3(1, verticalRange, range);
        rightGunTrigger.size = new Vector3(1, verticalRange, range);

        leftGunTrigger.center = new Vector3(0, 0, range * 0.5f);
        rightGunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, enemyLayerMask);

        // ADD AUDIO LOGIC HERE

        // ADD ANIMATION LOGIC HERE



    }

    private void OnTriggerEnter(Collider other)
    {
        // Add enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
