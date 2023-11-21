using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth = 2;
    private EnemyManager_Luka manager;

    private void Start()
    {
        manager = FindAnyObjectByType<EnemyManager_Luka>();
    }

    private void Update()
    {
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
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
