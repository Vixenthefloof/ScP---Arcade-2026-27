using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Options")]
    [SerializeField] private uint moveSpeed; // Creates a variable in unity that changes the MoveSpeed
    [SerializeField] private uint weaponType; // Creates a variable in unity that describes the current weapon Type
    [SerializeField] private Rigidbody2D _rb; //Creates a variable in unity that gets the current Rigidbody (Player)
    [SerializeField] private Vector2 moveInput;

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

}
