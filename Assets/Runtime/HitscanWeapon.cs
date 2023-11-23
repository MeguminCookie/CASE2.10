using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class HitscanWeapon : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField] private bool AddBulletSpread = true;
    [SerializeField] private Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private ParticleSystem ShootingSystem;
    //[SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private Transform LeftBulletSpawnPoint;
    [SerializeField] private Transform RightBulletSpawnPoint;
    [SerializeField] private GameObject ImpactParticleSystem;
    [SerializeField] private TrailRenderer BulletTrail;
    [SerializeField] private float ShootDelay = 0.5f;
    [SerializeField] private LayerMask Mask;
    [SerializeField] private float BulletSpeed = 100f;
    [SerializeField] private float firingAngle = 45f;
    [SerializeField] private float maxFiringDistance = 100f;
    private string currentBarrel;
    private Animator Animator;
    private float LastShootTime;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        // Corrected the layer mask assignment
        Mask = LayerMask.GetMask("Default", "Enemy");
    }
    private void Start()
    {
        currentBarrel = "Left";
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            if (currentBarrel == "Left")
            {
                ShootLeft();
                currentBarrel = "Right";
            }
            else if (currentBarrel == "Right")
            {
                ShootRight();
                currentBarrel = "Left";
            }
        }
    }
    public void ShootLeft()
    {
        if (LastShootTime + ShootDelay < Time.time)
        {
            Animator.SetBool("IsShooting", true);
            ShootingSystem.Play();
            Vector3 direction = GetDirectionToNearestEnemy();
            int randomDamage = Random.Range(1, 101);
            int damage;
            if (randomDamage <= 25)
            {
                damage = 1;
                Debug.Log("Damage roll: 1 damage");
            }
            else if (randomDamage <= 75)
            {
                damage = 2;
                Debug.Log("Damage roll: 2 damage");
            }
            else
            {
                damage = 3;
                Debug.Log("Damage roll: 3 damage");
            }
            if (Physics.Raycast(LeftBulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit with hitscan");
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();


                    //enemyHealth.TakeDamage(damage);
                    enemyHealth.Die();
                    Debug.Log("Enemy took damage!");



                    

                }
                TrailRenderer trail = Instantiate(BulletTrail, LeftBulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true));
                LastShootTime = Time.time;
                AudioSource.PlayClipAtPoint(clip, LeftBulletSpawnPoint.transform.position);
            }
            else
            {
                TrailRenderer trail = Instantiate(BulletTrail, LeftBulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, LeftBulletSpawnPoint.position + direction * maxFiringDistance, Vector3.zero, false));
                LastShootTime = Time.time;
            }
        }
    }
    public void ShootRight()
    {
        if (LastShootTime + ShootDelay < Time.time)
        {
            Animator.SetBool("IsShooting", true);
            ShootingSystem.Play();
            Vector3 direction = GetDirectionToNearestEnemy();
            int randomDamage = Random.Range(1, 101);
            int damage;
            if (randomDamage <= 25)
            {
                damage = 1;
                Debug.Log("Damage roll: 1 damage");
            }
            else if (randomDamage <= 75)
            {
                damage = 2;
                Debug.Log("Damage roll: 2 damage");
            }
            else
            {
                damage = 3;
                Debug.Log("Damage roll: 3 damage");
            }
            if (Physics.Raycast(RightBulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit with hitscan");
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();


                    // enemyHealth.TakeDamage(damage);
                    enemyHealth.Die();
                    Debug.Log("Enemy took damage!");



                    Debug.Log("EnemyHealth is not null.");

                }
                TrailRenderer trail = Instantiate(BulletTrail, RightBulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true));
                LastShootTime = Time.time;
                AudioSource.PlayClipAtPoint(clip, RightBulletSpawnPoint.transform.position);
            }
            else
            {
                TrailRenderer trail = Instantiate(BulletTrail, RightBulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, RightBulletSpawnPoint.position + direction * maxFiringDistance, Vector3.zero, false));
                LastShootTime = Time.time;
            }
        }
    }
    private Vector3 GetDirectionToNearestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxFiringDistance, Mask);
        Transform nearestEnemy = null;
        float nearestDistance = float.MaxValue;
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (IsWithinFiringAngle(collider.transform.position) && distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = collider.transform;
                }
            }
        }
        if (nearestEnemy != null)
        {
            // Visualize the firing angle
            Debug.DrawLine(transform.position, nearestEnemy.position, Color.green);
            Vector3 direction = (nearestEnemy.position - LeftBulletSpawnPoint.position).normalized; //MAYBE CHANGE
            if (AddBulletSpread)
            {
                direction += new Vector3(
                    Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
                    Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
                    Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
                );
                direction.Normalize();
            }
            return direction;
        }
        return transform.forward;
    }
    private bool IsWithinFiringAngle(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);
        return angleToTarget <= firingAngle * 0.5f;
    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, bool MadeImpact)
    {
        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;
        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));
            remainingDistance -= BulletSpeed * Time.deltaTime;
            yield return null;
        }
        Animator.SetBool("IsShooting", false);
        Trail.transform.position = HitPoint;
        if (MadeImpact)
        {
            Instantiate(ImpactParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
        }
        Destroy(Trail.gameObject, Trail.time);
    }
    // Draw the firing angle gizmo in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        float halfFiringAngle = firingAngle * 0.5f;
        float gizmoDistance = 10f; // You can adjust this distance based on your needs
        Vector3 leftDirection = Quaternion.Euler(0, -halfFiringAngle, 0) * Vector3.forward;
        Vector3 rightDirection = Quaternion.Euler(0, halfFiringAngle, 0) * Vector3.forward;
        Gizmos.DrawLine(Vector3.zero, leftDirection * gizmoDistance);
        Gizmos.DrawLine(Vector3.zero, rightDirection * gizmoDistance);
    }
}