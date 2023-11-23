using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth = 2;
    private EnemyManager_Luka manager;
    [SerializeField] private GameObject gamemanager;
    private float addTime;
    private CountdownTimer timer;


    private void Start()
    {
        
        timer = gamemanager.GetComponent<CountdownTimer>();
        manager = FindAnyObjectByType<EnemyManager_Luka>();
    }

    private void Update()
    {
        addTime = timer.GetTimeAdding();
        if (enemyHealth <= 0)
        {
            manager.RemoveEnemy(this);
            StartCoroutine(SmallDestoryCooldown());
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    private IEnumerator SmallDestoryCooldown()
    {
        yield return new WaitForSeconds(0.01f);
        timer.TimeAdder(addTime);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
