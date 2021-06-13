using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugmove : Movement
{
    public GameObject target;
    public float minWaitAmount = 0.5f;
    public float maxWaitAmount = 2.5f;
    private IEnumerator hopRoutine;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       hopRoutine = Hop(minWaitAmount, maxWaitAmount);
       StartCoroutine(hopRoutine);
       spr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!isGrounded && target != null)
        {
            if(Vector2.Dot(transform.right, (target.transform.position - transform.position)) < 0)
            {
                nextMove = -transform.right;
                spr.flipX = false;
            }
            else
            {
                nextMove = transform.right;
                spr.flipX = true;
            }
        }
        else
        {
            nextMove = Vector3.zero;
        }
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
