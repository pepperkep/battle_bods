using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody rb;
    private Vector2 nextMove;


    public void Move(InputAction.CallbackContext context)
    {
        nextMove = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + ((Vector3)(nextMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed)));
    }
}