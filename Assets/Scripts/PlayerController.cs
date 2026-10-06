using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private uint moveSpeed; // Creates a variable in unity that changes the MoveSpeed
    public uint weaponType; // Creates a variable in unity that describes the current weapon Type
    [SerializeField] private Rigidbody2D _rb; //Creates a variable in unity that gets the current Rigidbody (Player)
    public uint playerLives;
    [SerializeField] private Vector2 moveInput;

    [Header("Gun Settings")]
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bulletProj;
    [SerializeField] float bulletSPD;
    [SerializeField] float bulletCool;
    [SerializeField] bool canFire;

    public PrefabAssetType NormalShot;

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
                var bullet = Instantiate(Resources.Load<GameObject>("Items/normalShot"));
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawn.up * bulletSPD;
            }
        }
        else
        {
            return;
        }
        canFire = false;
        StartCoroutine(bulletCooldown());
    }

    IEnumerator bulletCooldown()
    {
        yield return new WaitForSeconds(bulletCool);
        canFire = true;
    }

}
