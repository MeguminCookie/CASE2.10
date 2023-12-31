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

   
}
