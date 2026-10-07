using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private uint moveSpeed; // Move Speed Variable
    public uint weaponType; // Players Weapon Type Variable
    [SerializeField] private Rigidbody2D _rb; // Player Rigidbody Variable
    public uint playerLives; // Players Live Count Variable
    [SerializeField] private Vector2 moveInput; // Gets current movement of the player

    [Header("Gun Settings")]
    [SerializeField] Transform bulletSpawn; // Variable to get the current spawnpoint of the Bullets
    [SerializeField] GameObject bulletProj1; // Bullet Projectile #1
    [SerializeField] GameObject bulletProj2; // Bullet Projectile #2
    [SerializeField] GameObject bulletProj3; // Bullet Projectile #3
    [SerializeField] float BulletArc; // Variable that determines the arc of the Shotgun Weapon
    [SerializeField] float bulletSPD; // Variable that sets the bullet Speed
    [SerializeField] float bulletCool1; // Variable that sets the cooldown of the gun
    [SerializeField] float bulletCool2; // Variable that sets the cooldown of the 2nd gun
    [SerializeField] float bulletCool3; // Variable that sets the cooldown of the 3rd gun
    [SerializeField] bool canFire; // Can the player fire at this moment Variable
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext ctx) //allows the player to move
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void Fire(InputAction.CallbackContext ctx) // Allows the player to fire
    {   
        if (canFire == true)
        {
            if (weaponType == 0)
            {
                var bullet1 = Instantiate(bulletProj1, bulletSpawn.position, bulletSpawn.rotation);
                bullet1.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawn.up * bulletSPD;

            }
            else if (weaponType == 1)
            { 
                var bullet2 = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                var bullet2l = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                var bullet2r = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                bullet2.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawn.up * BulletArc;
                bullet2l.GetComponent<Rigidbody2D>().linearVelocity = (bulletSpawn.up * BulletArc) - transform.right;
                bullet2r.GetComponent<Rigidbody2D>().linearVelocity = (bulletSpawn.up * BulletArc) + transform.right;
            }
            else if (weaponType == 2)
            {
                var bullet3 = Instantiate(bulletProj3, bulletSpawn.position, bulletSpawn.rotation);
                bullet3.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawn.up * bulletSPD/2;
            }
        }
        else
        {
            return;
        }
        canFire = false;
        StartCoroutine(bulletCooldown()); // Starts a cooldown for the fire rate
    }

    IEnumerator bulletCooldown() //Cooldown for the fire rate
    {
        if (weaponType == 0)
        {
            yield return new WaitForSeconds(bulletCool1);
            canFire = true;
        }
        else if (weaponType == 1)
        {
            yield return new WaitForSeconds(bulletCool2);
            canFire = true;
        }
        else if (weaponType == 2)
        {
            yield return new WaitForSeconds(bulletCool3);
            canFire = true;
        }
    }

}
