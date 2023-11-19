using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    private int randomNumber;
    [SerializeField] private int spawnTime;
    private bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSpawned)
        { 
        }
        else
        {
            StartCoroutine(SpawnEnemies(spawnTime));
        }
        
    }

    private IEnumerator SpawnEnemies(float spawnTime)
    {
        randomNumber = Random.Range(0,spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomNumber]);
        hasSpawned = true;
        yield return new WaitForSeconds(spawnTime);
        hasSpawned = false;
    }
}
