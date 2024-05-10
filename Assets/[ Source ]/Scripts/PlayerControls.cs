using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [HideInInspector] public Vector2 CurrentMovementDirection { get; private set; }

    public event Action interactAction;
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
        CurrentMovementDirection = inputContext.ReadValue<Vector2>().normalized;
        rigidBody.velocity = CurrentMovementDirection * moveSpeed;
    }

    public void Interact(InputAction.CallbackContext inputContext)
    {
        interactAction?.Invoke();
    }

    public void QuitGame(InputAction.CallbackContext inputContext)
    {
        Application.Quit();
    }
}
