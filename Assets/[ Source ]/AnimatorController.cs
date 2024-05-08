using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement player;

    void Start()
    {
        player = transform.parent.GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    public void MoveAnimation(InputAction.CallbackContext inputContext)
    {
        Vector2 movementVector = inputContext.ReadValue<Vector2>();
        bool moving = movementVector != Vector2.zero;

        animator.SetBool("Moving", moving);
        if (moving)
        {
            animator.SetFloat("X", movementVector.x);
            animator.SetFloat("Y", movementVector.y);
        }
    }
}
