using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to your enemy prefab
    public float spawnRadius = 10f; // Radius around the player for spawning
    public float minDistanceToPlayer = 5f; // Minimum distance from the player

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, Random.Range(1f, 5f)); // Repeat the spawning function at random intervals
    }

    void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = GetRandomSpawnPoint();
        Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPoint()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(minDistanceToPlayer, spawnRadius);
        Vector3 spawnPoint = new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;

        return spawnPoint;
    }
}