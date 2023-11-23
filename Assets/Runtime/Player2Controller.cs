using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    public float rotationSpeed = 5f;
    //public GameObject projectilePrefab;
    //public Transform projectileSpawnPoint;

    //public float firingRate = 0.5f; // Adjust this value to set the firing rate in seconds
    //public float projectileForce = 10f; // Adjust this value to set the for
    //private float nextFireTime;

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
       if(Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(0, -80f* Time.deltaTime, 0);
        }
       else if(Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(0, 80f* Time.deltaTime, 0);
        }
    }
    
    /*
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
