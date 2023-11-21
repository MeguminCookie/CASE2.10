using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_Luka : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        Debug.Log("Enter");
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Debug.Log("exit");
        enemiesInTrigger.Remove(enemy);
    }
}
