using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    protected Rigidbody rb;
    protected Animator animator;
    protected Vector2 nextMove;
    public float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + ((Vector3)(nextMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed)));
    }
}
