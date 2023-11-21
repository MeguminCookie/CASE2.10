using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<EnemyHealth> enemyList = new List<EnemyHealth>();
    [SerializeField] private float fireRate;
    [SerializeField] private float fireTime;
    [SerializeField] private int damage = 2;
    [SerializeField] private float range = 60f;
    private EnemyHealth health;

    [SerializeField]private LayerMask obstructionLayerMask;

    private BoxCollider gunCollider;
    // Start is called before the first frame update
    void Start()
    {
        range = 60;
        gunCollider = this.gameObject.GetComponent<BoxCollider>();
        gunCollider.size = new Vector3(10f, 20f,range);
        gunCollider.center = new Vector3(0, 0, range * 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame && fireTime <= Time.time)
        { 
            Fire();
        }
    }


    private void Fire()
    {

        foreach (var enemy in enemyList) 
        {
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            Debug.Log("Is firing");
            if (Physics.Raycast(transform.position,dir,out hit, obstructionLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    Debug.Log("Is firing at enemy");
                    enemy.TakeDamage(damage);
                    
                }
            }

               
        }
        

        fireTime = Time.time + fireRate;
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = GetComponent<EnemyHealth>();

        Debug.Log("Enemy in trigger");
        if (enemy)
        {
            enemyList.Add(enemy);
            Debug.Log("Added Enemy");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        EnemyHealth enemy = GetComponent<EnemyHealth>();

        if(enemy)
        {
            enemyList.Remove(enemy);
        }
    }






}
