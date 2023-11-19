using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{
    [SerializeField] private GameObject gameTimerCountdown;
    private CountdownTimer gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = gameTimerCountdown.GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            gameTimer.TimeAdder(-10f);
        }
    }
}
