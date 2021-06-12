using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 6;
    private bool moveTowards = true;
    private Rigidbody rb;
    private IEnumerator dirCoroutine;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       dirCoroutine = SwitchDirection(0.3f, 2.0f);
       StartCoroutine(dirCoroutine);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.left;
        if(!moveTowards)
            moveDirection = Vector3.right;
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
    }

    IEnumerator SwitchDirection(float minMove, float maxMove)
    {
        while(true)
        {
            float timeToSwitch = Random.Range(minMove, maxMove);
            yield return new WaitForSeconds(timeToSwitch);
            this.moveTowards = !this.moveTowards;
        }
    }
}
