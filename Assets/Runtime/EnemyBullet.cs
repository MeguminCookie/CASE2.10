using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float timeDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private GameObject textPrefab;
    private GameObject textSpawn;
    private GameObject gameManager;
    private CountdownTimer timer;
    private Rigidbody rb;


    private void Start()
    {
        textSpawn = GameObject.FindGameObjectWithTag("TextSpawn");
        gameManager = GameObject.Find("Gamemanager");
        timer = gameManager.GetComponent<CountdownTimer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timeDamage = timer.GetTimeDamage();
        rb.MovePosition(transform.position - transform.forward * Time.deltaTime * bulletSpeed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            timer.TimeAdder(timeDamage);
            Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Instantiate(textPrefab,textSpawn.transform.position, textSpawn.transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Building"))
        {
            Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public float GetTimeDamage()
    {
        return timeDamage;
    }


}
