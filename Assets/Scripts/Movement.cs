using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    protected Rigidbody rb;
    protected Animator animator;
    protected Vector2 nextMove;
    protected Vector2 velocity;
    public Vector2 gravity = new Vector2(0, -9.8f);
    public float errorAmount = 0.0001f;
    public float moveSpeed;
    public float jumpVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void Jump()
    {
        this.velocity.y += jumpVelocity;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
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
        if(displacement.y < 0.01f)
            displacement.y = 0;
        rb.MovePosition(rb.position + displacement);
    }
}
