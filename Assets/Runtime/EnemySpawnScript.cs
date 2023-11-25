using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    private int randomNumber;
    private GameObject gamemanager;
    private CountdownTimer timer;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject spawnVFX;
    private bool hasSpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        timer = gamemanager.GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = timer.GetSpawnTime();
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
        hasSpawned = true;
        randomNumber = Random.Range(0,spawnPoints.Length);
        Instantiate(spawnVFX, spawnPoints[randomNumber]);
        yield return new WaitForSeconds(0.4f);
        Instantiate(enemyPrefab, spawnPoints[randomNumber]);
       
        yield return new WaitForSeconds(spawnTime);
        hasSpawned = false;
    }
}
