using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private Gun gunComponent;
    private IEnumerator gunCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        gunComponent = gameObject.GetComponent<Gun>();
        gunCoroutine = FireSometimes(0.3f, 1.0f);
        StartCoroutine(gunCoroutine);
    }
    IEnumerator FireSometimes(float minMove, float maxMove)
    {
        while(true)
        {
            float timeToSwitch = Random.Range(minMove, maxMove);
            yield return new WaitForSeconds(timeToSwitch);
            gunComponent.Fire();
        }
    }
}
