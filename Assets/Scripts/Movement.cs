using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    protected Rigidbody rb;
    protected Animator animator;
    protected Vector2 nextMove;
    protected Vector2 velocity;
    protected bool isGrounded = true;
    public Vector2 gravity = new Vector2(0, -9.8f);
    public float errorAmount = 0.0001f;
    public float moveSpeed;
    public float jumpVelocity;
    public GameObject groundCheckPoint;
    public float groundCheckDistance = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void Jump()
    {
        isGrounded = false;
        this.velocity.y += jumpVelocity;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit rhit;
        if(!isGrounded && Vector2.Dot(velocity, gravity) > 0)
        {
            bool groundCastResult = Physics.Raycast(groundCheckPoint.transform.position, Vector3.down, out rhit, this.groundCheckDistance);
            isGrounded = groundCastResult;
        }
        RaycastHit[] hits = new RaycastHit[128];
        Vector3 displacement = ((Vector3)(nextMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed));
        this.velocity += gravity * Time.fixedDeltaTime;
        displacement += (Vector3)(velocity * Time.fixedDeltaTime);
        hits = rb.SweepTestAll(displacement.normalized, Mathf.Abs(displacement.magnitude));
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.CompareTag("Wall"))
            {
                displacement -= (displacement.magnitude - hit.distance + errorAmount) * -hit.normal;
                this.velocity = Vector2.zero;
            }
        }
        if(displacement.y < 0.01f && isGrounded)
            displacement.y = 0;
        rb.MovePosition(rb.position + displacement);
    }
}
