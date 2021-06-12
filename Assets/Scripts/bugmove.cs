using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugmove : Movement
{
    public GameObject target;
    public float minWaitAmount = 0.5f;
    public float maxWaitAmount = 2.5f;
    private IEnumerator hopRoutine;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       hopRoutine = Hop(minWaitAmount, maxWaitAmount);
       StartCoroutine(hopRoutine);
    }

    void Update()
    {
        /*
        Vector3 moveDirection = Vector2.left;
        if(!moveTowards)
            moveDirection = Vector2.right;
        nextMove = moveDirection;
        this.animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
        */
    }

    IEnumerator Hop(float minDuration, float maxDuration)
    {
        while(true)
        {
            float timeToSwitch = Random.Range(minDuration, maxDuration);
            yield return new WaitForSeconds(timeToSwitch);
            Jump();
        }
    }
}
