using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerFire : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletProj;
    public float bulletSPD;

    public void Fire(InputAction.CallbackContext ctx) // Allows the player to fire
    {

    }
}
