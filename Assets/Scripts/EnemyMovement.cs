using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement 
{

    private bool moveTowards = true;
    private IEnumerator dirCoroutine;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       dirCoroutine = SwitchDirection(0.3f, 2.0f);
       StartCoroutine(dirCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector2.left;
        if(!moveTowards)
            moveDirection = Vector2.right;
        nextMove = moveDirection;
        this.animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
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
