using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DualBarrelHitscanWeapon : MonoBehaviour
{
    [SerializeField] private bool AddBulletSpread = true;
    [SerializeField] private Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private ParticleSystem ShootingSystem;
    [SerializeField] private Transform LeftBulletSpawnPoint;
    [SerializeField] private Transform RightBulletSpawnPoint;
    [SerializeField] private ParticleSystem ImpactParticleSystem;
    [SerializeField] private TrailRenderer BulletTrail;
    [SerializeField] private float ShootDelay = 0.5f;
    [SerializeField] private LayerMask Mask;
    [SerializeField] private float BulletSpeed = 100f;
    [SerializeField] private float firingAngle = 45f;
    [SerializeField] private float maxFiringDistance = 100f;

    private Animator Animator;
    private float LastShootTime;
    private bool isLeftBarrel = true;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Mask = LayerMask.GetMask("Default", "Enemy");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Shoot();
        }
    }

    public void Shoot()
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

            Transform bulletSpawnPoint = isLeftBarrel ? LeftBulletSpawnPoint : RightBulletSpawnPoint;

            if (Physics.Raycast(bulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit with hitscan");
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damage);
                        Debug.Log("Enemy took damage!");
                    }
                    else
                    {
                        Debug.LogError("EnemyHealth is not null.");
                    }
                }

                TrailRenderer trail = Instantiate(BulletTrail, bulletSpawnPoint.position, Quaternion.identity);

                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, true));

                LastShootTime = Time.time;

                // Switch barrel for the next shot
                isLeftBarrel = !isLeftBarrel;
            }
            else
            {
                TrailRenderer trail = Instantiate(BulletTrail, bulletSpawnPoint.position, Quaternion.identity);

                StartCoroutine(SpawnTrail(trail, bulletSpawnPoint.position + direction * maxFiringDistance, Vector3.zero, false));

                LastShootTime = Time.time;
            }
        }
    }

    private Vector3 GetDirectionToNearestEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxFiringDistance, Mask);
        Transform nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        Transform currentBarrel = isLeftBarrel ? LeftBulletSpawnPoint : RightBulletSpawnPoint;

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
            Debug.DrawLine(currentBarrel.position, nearestEnemy.position, Color.green);

            Vector3 direction = (nearestEnemy.position - currentBarrel.position).normalized;

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

        return currentBarrel.forward;
    }

    private bool IsWithinFiringAngle(Vector3 targetPosition)
    {
        // Use the current barrel's position for the firing angle calculation
        Transform currentBarrel = isLeftBarrel ? LeftBulletSpawnPoint : RightBulletSpawnPoint;

        Vector3 directionToTarget = targetPosition - currentBarrel.position;
        float angleToTarget = Vector3.Angle(currentBarrel.forward, directionToTarget);

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
