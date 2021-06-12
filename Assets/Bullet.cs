using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.MovePosition(rb.position + transform.right * moveSpeed * Time.fixedDeltaTime) ;
    }
}
