using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement 
{

    public void Move(InputAction.CallbackContext context)
    {
        nextMove = context.ReadValue<Vector2>();
        animator.SetFloat("speed", Mathf.Abs(nextMove.x));
    }
}
