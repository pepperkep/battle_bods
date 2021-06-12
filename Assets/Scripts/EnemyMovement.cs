using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 6;
    private bool moveTowards = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.left;
        if(!moveTowards)
            moveDirection = Vector3.right;
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
    }
}
