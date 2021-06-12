using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health;

    public void Update()
    {
        if(health <= 0)
            Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider col)
    {
        Damager hurtbox = col.gameObject.GetComponent<Damager>();
        if(hurtbox != null)
            health -= hurtbox.damage;
    }
}
