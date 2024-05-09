using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;

    [NonSerialized] public Vector2 currentMovementDirection;
        
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Move(InputAction.CallbackContext inputContext)
    {
        currentMovementDirection = inputContext.ReadValue<Vector2>().normalized;
        rigidBody.velocity = currentMovementDirection * moveSpeed;
    }
}
