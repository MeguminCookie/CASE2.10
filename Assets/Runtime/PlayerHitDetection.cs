using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{
    [SerializeField] private GameObject gameTimerCountdown;
    private EnemyBullet enemyBullet;
    private CountdownTimer gameTimer;
    private float timeDamage;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = gameTimerCountdown.GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeDamage = gameTimer.GetTimeDamage();
    }

    private void OnCollsionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            enemyBullet = other.gameObject.GetComponent<EnemyBullet>();
            gameTimer.TimeAdder(timeDamage);
            
            
        }
    }
}
