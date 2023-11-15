using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float firingRate = 0.5f; // Adjust this value to set the firing rate in seconds
    public float projectileForce = 10f; // Adjust this value to set the for
    private float nextFireTime;

    //public BaseWeapon[] weapons;
    //public int currentWeaponIndex = 0;
    private void Start()
    {
        //EquipCurrentWeapon();
    }
    void Update()
    {
        // Rotate upper body
        RotateUpperBody();
        /*
        // Fire projectile
        if (Input.GetKey(KeyCode.U) && Time.time > nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / firingRate;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchToNextAvailableWeapon();
        }
        */
    }

    void RotateUpperBody()
    {
        float verticalRotation = Input.GetKey(KeyCode.K) ? rotationSpeed : (Input.GetKey(KeyCode.I) ? -rotationSpeed : 0f);
        float horizontalRotation = Input.GetKey(KeyCode.L) ? rotationSpeed : (Input.GetKey(KeyCode.J) ? -rotationSpeed : 0f);

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        float clampedVerticalRotation = Mathf.Clamp(currentRotation.x + verticalRotation, 0f, 0f);

        transform.localRotation = Quaternion.Euler(clampedVerticalRotation, currentRotation.y + horizontalRotation, currentRotation.z);
    }

    void FireProjectile()
    {
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(projectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }
    /*
    public void SwitchToNextAvailableWeapon()
    {
        int originalIndex = currentWeaponIndex;

        do
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        } while (currentWeaponIndex != originalIndex && weapons[currentWeaponIndex].currentAmmo == 0);

        EquipCurrentWeapon();
    }

    void EquipCurrentWeapon()
    {
        // Disable all weapons
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        // Enable the current weapon
            weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
    */

}
