using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    private static Animator animator;

    void Start()
    {
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

    public static void ChangeClothes(ItemData itemData)
    {
        if (animator.GetInteger(itemData.BodyLayer) == itemData.AnimationsIndex)
            animator.SetInteger(itemData.BodyLayer, 0);
        else
            animator.SetInteger(itemData.BodyLayer, itemData.AnimationsIndex);

        animator.SetTrigger("ChangeSprite");
    }
}
