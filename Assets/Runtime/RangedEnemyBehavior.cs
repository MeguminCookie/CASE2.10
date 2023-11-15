using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float stopDistance;
    [SerializeField] private float range = 20f;
    [SerializeField] private LayerMask raycastLayerMask;
    private NavMeshAgent enemyNavMeshAgent;

    private float distance = 0;

    private void Start()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        distance = dist;
        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        if (distance >= stopDistance)
        {
            enemyNavMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            enemyNavMeshAgent.SetDestination(transform.position);
        }
        yield return null;
    }
}
