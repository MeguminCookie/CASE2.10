using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class EnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shootingLocation;
    [SerializeField] private GameObject bulletPrefabs;

    [SerializeField] private float shootingCD;
    private EnemyFieldOfView enemyFOV;
    private bool canShoot;
    public AudioClip clip; //make sure you assign an actual clip here in the inspector

    void Start()
    {
        canShoot = true;
        enemyFOV = GetComponent<EnemyFieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot && enemyFOV.canSeePlayer)
        {
            StartCoroutine(Shooting(shootingCD));
        }
    }


    private IEnumerator Shooting(float shootingCD)
    {
        Instantiate(bulletPrefabs,shootingLocation.transform.position,shootingLocation.transform.rotation);
        canShoot=false;
        yield return new WaitForSeconds(shootingCD);
        canShoot = true;
        AudioSource.PlayClipAtPoint(clip, shootingLocation.transform.position);
    }
}
