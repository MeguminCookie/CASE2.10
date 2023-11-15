using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Projectile Prefab
    public GameObject pistolAmmoPrefab;
    public GameObject minigunAmmoPrefab;
    public GameObject grenadeAmmoPrefab;
    public GameObject missileAmmoPrefab;
    public GameObject rocketAmmoPrefab;
    public GameObject railgunAmmoPrefab;

    // Projectile Spawnpoints
    public Transform pistolProjectileSpawnPoint;
    public Transform minigunProjectileSpawnPoint;
    public Transform grenadeProjectileSpawnPoint;
    public Transform missileProjectileSpawnPoint;
    public Transform rocketProjectileSpawnPoint;
    public Transform railgunProjectileSpawnPoint;

    // Max ammo
    public int pistolMaxAmmo = 9999999;
    public int minigunMaxAmmo = 2500;
    public int grenadeMaxAmmo = 100;
    public int missileMaxAmmo = 10;
    public int rocketMaxAmmo = 50;
    public int railgunMaxAmmo = 10;

    // Weapon firerates
    public float pistolFireRate = 1f;
    public float minigunFireRate = 10f;
    public float grenadeFireRate = 1.5f;
    public float missileFireRate = 5f;
    public float rocketFireRate = 4f;
    public float railgunFireRate = 10f;

    // Weapon current ammo
    public int pistolCurrentAmmo = 9999999;
    public int minigunCurrentAmmo = 0;
    public int grenadeCurrentAmmo = 0;
    public int missileCurrentAmmo = 0;
    public int rocketCurrentAmmo = 0;
    public int railgunCurrentAmmo = 0;

    // Next fire time
    private float pistolNextFireTime;
    private float minigunNextFireTime;
    private float grenadeNextFireTime;
    private float missileNextFireTime;
    private float rocketNextFireTime;
    private float railgunNextFireTime;

    public int currentAmmo;


    public float projectileForce = 10f; // Adjust this value to set the for

    public string currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = "Pistol";   
    }

    // Update is called once per frame
    void Update()
    {
        // Update current ammo
        if (currentWeapon == "Pistol")
        {
            currentAmmo = pistolCurrentAmmo;
        }
        else if (currentWeapon == "Minigun")
        {
            currentAmmo = minigunCurrentAmmo;
        }
        else if (currentWeapon == "Grenade")
        {
            currentAmmo = grenadeCurrentAmmo;
        }
        else if (currentWeapon == "Missile")
        {
            currentAmmo = missileCurrentAmmo;
        }
        else if (currentWeapon == "Rocket")
        {
            currentAmmo = rocketCurrentAmmo;
        }
        else if (currentWeapon == "Railgun")
        {
            currentAmmo = railgunCurrentAmmo;
        }
        // Check current ammo
        if (currentAmmo <= 0)
        {
            NextWeapon();
        }

        // Fire
        if (Input.GetKey(KeyCode.U))
        {
            if (currentWeapon == "Pistol")
            {
                if (Time.time > pistolNextFireTime)
                {
                    FirePistol();
                    pistolNextFireTime = Time.time + 1f / pistolFireRate;
                }
            }
            else if (currentWeapon == "Minigun")
            {
                if (Time.time > minigunNextFireTime)
                {
                    FireMinigun();
                    minigunNextFireTime = Time.time + 1f / minigunFireRate;
                }
            }
            else if (currentWeapon == "Grenade")
            {
                if (Time.time > grenadeNextFireTime)
                {
                    FireGrenade();
                    grenadeNextFireTime = Time.time + 1f / grenadeFireRate;
                }
            }
            else if (currentWeapon == "Missile")
            {
                if (Time.time > missileNextFireTime)
                {
                    FireMissile();
                    missileNextFireTime = Time.time + 1f / missileFireRate;
                }
            }
            else if (currentWeapon == "Rocket")
            {
                if (Time.time > rocketNextFireTime)
                {
                    FireRocket();
                    rocketNextFireTime = Time.time + 1f / rocketFireRate;
                }
            }
            else if (currentWeapon == "Railgun")
            {
                if (Time.time > minigunNextFireTime)
                {
                    FireRailgun();
                    railgunNextFireTime = Time.time + 1f / railgunFireRate;
                }
            }
            else
            {
                Debug.Log("Weapon not found. Switching to default...");
                currentWeapon = "Pistol";
            }
        }

        // Change weapon
        if (Input.GetKey(KeyCode.O))
        {
            NextWeapon();
        }
    }

    void NextWeapon()
    {
        if(currentWeapon == "Pistol")
        {
            currentWeapon = "Minigun";
            currentAmmo = minigunCurrentAmmo;
        }
        else if(currentWeapon == "Minigun")
        {
            currentWeapon = "Grenade";
            currentAmmo = grenadeCurrentAmmo;
        }
        else if (currentWeapon == "Grenade")
        {
            currentWeapon = "Missile";
            currentAmmo = missileCurrentAmmo;
        }
        else if (currentWeapon == "Missile")
        {
            currentWeapon = "Rocket";
            currentAmmo = rocketCurrentAmmo;
        }
        else if (currentWeapon == "Rocket")
        {
            currentWeapon = "Railgun";
            currentAmmo = railgunCurrentAmmo;
        }
        else if (currentWeapon == "Railgun")
        {
            currentWeapon = "Pistol";
            currentAmmo = pistolCurrentAmmo;
        }
        else
        {
            Debug.Log("An error occured while trying to switch weapon. Switching to default weapon...");
            currentWeapon = "Pistol";
            pistolCurrentAmmo = 99999;
        }
    }

    void FirePistol()
    {
        if (pistolAmmoPrefab!= null && pistolProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(pistolAmmoPrefab, pistolProjectileSpawnPoint.position, pistolProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(pistolProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    void FireMinigun()
    {
        if (minigunAmmoPrefab != null && minigunProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(minigunAmmoPrefab, minigunProjectileSpawnPoint.position, minigunProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(minigunProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    void FireGrenade()
    {
        if (grenadeAmmoPrefab != null && grenadeProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(grenadeAmmoPrefab, grenadeProjectileSpawnPoint.position, grenadeProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(grenadeProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    void FireMissile()
    {
        if (missileAmmoPrefab != null && missileProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(missileAmmoPrefab, missileProjectileSpawnPoint.position, missileProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(missileProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    void FireRocket()
    {
        if (rocketAmmoPrefab != null && rocketProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(rocketAmmoPrefab, rocketProjectileSpawnPoint.position, rocketProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(rocketProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }

    void FireRailgun()
    {
        if (railgunAmmoPrefab != null && railgunProjectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(railgunAmmoPrefab, railgunProjectileSpawnPoint.position, railgunProjectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(railgunProjectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);
            }
        }
    }
}
