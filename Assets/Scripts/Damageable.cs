using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health;
    public bool isEnemy = false;
    public List<GameObject> dependentObjects;

    public void Update()
    {
        if(health <= 0)
        {
            foreach (GameObject obj in dependentObjects)
            {
                Destroy(obj);
            }
            if(gameObject.CompareTag("Arm"))
                ArmDeath();
            else
                Destroy(this.gameObject);
        }
    }

    public void ArmDeath()
    {
        transform.parent.GetComponent<Animator>().enabled = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void OnTriggerEnter(Collider col)
    {
        Damager hurtbox = col.gameObject.GetComponent<Damager>();
        if(hurtbox != null && ((hurtbox.damageEnemy && isEnemy) || (hurtbox.damagePlayer && !isEnemy)))
        {
            health -= hurtbox.damage;
            if(hurtbox.destroyOnContact)
                Destroy(hurtbox.gameObject);
        }
    }
}
