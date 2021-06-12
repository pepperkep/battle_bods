using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    protected Rigidbody rb;
    protected Animator animator;
    protected Vector2 nextMove;
    public float errorAmount = 0.01f;
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
        RaycastHit[] hits = new RaycastHit[128];
        Vector3 displacement = ((Vector3)(nextMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed));
        hits = rb.SweepTestAll(displacement.normalized, Mathf.Abs(displacement.magnitude));
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.CompareTag("Wall"))
            {
                if(hit.distance < displacement.magnitude)
                    displacement = (hit.distance - errorAmount) * displacement.normalized;
            }
        }
        rb.MovePosition(rb.position + displacement);
    }
}
