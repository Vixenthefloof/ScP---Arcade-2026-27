using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
public class enemyAIScript : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float health;
    [SerializeField] float destroySecondsDelay;
    [SerializeField] float iFrameSeconds;
    [SerializeField] string destroyAnimName;
    public uint weaponType; // Enemy Weapon Type Variable
    public string eDelTag1 = "levelBottom"; // Deletion tags
    public string eDelTag2 = "bulletTag";
    public Animator _anim; // Gets the current animator
    [SerializeField] bool isDead; // checks if the enemy is dead

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
    [SerializeField] bool canFire; // Can the enemy fire at this moment?
    [SerializeField] bool canDmg; // Can the enemy be damaged

    private void Awake()
    {
        _anim = GetComponent<Animator>(); // Gets the current animator
    }

    private void Update()
    {
        if (isDead == false)
        {
            if (canFire == true)
            {
                if (weaponType == 0)
                {
                    var bullet1 = Instantiate(bulletProj1, bulletSpawn.position, bulletSpawn.rotation);
                    bullet1.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawn.up * bulletSPD;

                }
                else if (weaponType == 1)
                {
                    var bullet2 = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                    var bullet2l = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                    var bullet2r = Instantiate(bulletProj2, bulletSpawn.position, bulletSpawn.rotation);
                    bullet2.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawn.up * BulletArc;
                    bullet2l.GetComponent<Rigidbody2D>().linearVelocity = (-bulletSpawn.up * BulletArc) - transform.right;
                    bullet2r.GetComponent<Rigidbody2D>().linearVelocity = (-bulletSpawn.up * BulletArc) + transform.right;
                }
                else if (weaponType == 2)
                {
                    var bullet3 = Instantiate(bulletProj3, bulletSpawn.position, bulletSpawn.rotation);
                    bullet3.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawn.up * bulletSPD / 2;
                }
            }
            else
            {
                return;
            }
            canFire = false;
            StartCoroutine(bulletCooldown()); // Starts a cooldown for the fire rate
        }
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
    private void OnCollisionEnter2D(Collision2D other) // On collision
    {
        if (other.gameObject.CompareTag(eDelTag1)) // if the Enemy interacts with tag 1 delete
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag(eDelTag2)) // if the Enemy interacts with tag 2 do;
        {
            if (canDmg == true)
            {
                health--;
                _anim.Play("fighterDmg");
                canDmg = false;
                StartCoroutine(enemyAnim());
            }
            else if (health == 0)
            {
                Destroy(GetComponent<Collider2D>()); // Removes Collider
                _anim.Play("Explosion"); // Plays animation
                canFire = false;
                isDead = true;
                StartCoroutine(enemyAnim()); // Starts an animation cooldown
            }
        }
    }

    IEnumerator enemyAnim() // Starts a cooldown
    {
        if (isDead == true)
        {
            yield return new WaitForSeconds(destroySecondsDelay); // Waits for the amount of seconds given
            Destroy(gameObject); // Destroys enemy
        }
        else if (isDead == false && canDmg == false)
        {
            yield return new WaitForSeconds(iFrameSeconds);
            _anim.Play("fighterIdle");
            canDmg = true;
        }
    }
}
