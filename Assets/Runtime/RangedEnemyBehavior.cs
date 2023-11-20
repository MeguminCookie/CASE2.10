using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyBehavior : MonoBehaviour
{

    [Header("AI-Stuff")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float stopDistance;
    [SerializeField] private float range = 20f; 
    [SerializeField] private LayerMask raycastLayerMask;

    [SerializeField] private float largerShootInterval = 3f;
    [SerializeField] private float smallerShootInterval = 1f;
    [SerializeField] private Transform largerWeaponTransform;
    [SerializeField] private Transform smallerWeaponTransform;
    [SerializeField] private float bulletForce = 10f; // Adjust this value based on your needs

    public GameObject smallBullet;
    public GameObject largeBullet;
    public GameObject player;


    private NavMeshAgent enemyNavMeshAgent;

    private float distance = 0;
    private bool canShootSmall = true;
    private bool canShootLarge = true;
    private EnemyFieldOfView enemyFieldOfView;



    private void Start()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyFieldOfView = GetComponent<EnemyFieldOfView>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        //StartCoroutine(ShootTimerSmall());
        //StartCoroutine(ShootTimerLarge());
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        distance = dist;
        StartCoroutine(MoveEnemy());

        //TryShootLarge(largerWeaponTransform);
        //TryShootSmall(smallerWeaponTransform);

    }
    /*private IEnumerator ShootTimerSmall()
    {
        while (true)
        {
            yield return new WaitForSeconds(largerShootInterval);
            canShootLarge = true;
        }
    }

    private IEnumerator ShootTimerLarge()
    {
        while (true)
        {
            yield return new WaitForSeconds(smallerShootInterval);
            canShootLarge = true;
        }
    }

    private void TryShootSmall(Transform smallerWeaponTransform)
    {
        if (canShootSmall && enemyFieldOfView.canSeePlayer)
        {
            // Instantiate a bullet at the weapon's position and rotation
            GameObject bullet = Instantiate(smallBullet, smallerWeaponTransform.position, smallerWeaponTransform.rotation);

            // Get the Rigidbody component of the bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Check if the bullet has a Rigidbody component
            if (bulletRigidbody != null)
            {
                // Add force to the bullet in the forward direction of the largerWeaponTransform
                bulletRigidbody.AddForce(smallerWeaponTransform.forward * bulletForce, ForceMode.Impulse);
            }

            canShootSmall = false;
        }
    }

    private void TryShootLarge(Transform largerWeaponTransform)
    {
        if (canShootLarge && enemyFieldOfView.canSeePlayer)
        {
            // Instantiate a bullet at the weapon's position and rotation
            GameObject bullet = Instantiate(largeBullet, largerWeaponTransform.position, largerWeaponTransform.rotation);

            // Get the Rigidbody component of the bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Check if the bullet has a Rigidbody component
            if (bulletRigidbody != null)
            {
                // Add force to the bullet in the forward direction of the largerWeaponTransform
                bulletRigidbody.AddForce(largerWeaponTransform.forward * bulletForce, ForceMode.Impulse);
            }

            canShootLarge = false;
        }
    } */

    /*
    private bool HasLineOfSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, range, raycastLayerMask))
        {
            return hit.collider.CompareTag("Player"); // Adjust the tag based on your player's tag
        }
        return false;
    }
    */

    private IEnumerator MoveEnemy()
    {
        if (distance >= stopDistance)
        {
            enemyNavMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            if (!enemyFieldOfView.canSeePlayer)
            {
                enemyNavMeshAgent.SetDestination(playerTransform.position);
            }
            else
            {
                enemyNavMeshAgent.SetDestination(transform.position);
            }
        }
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            


        }

    }
}
