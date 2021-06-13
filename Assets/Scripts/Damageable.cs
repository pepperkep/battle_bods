using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health;
    public bool isEnemy = false;
    public bool isDead = false;
    public List<GameObject> dependentObjects;
    public int resetHealthValue = 10;

    public void Update()
    {
        if(health <= 0)
        {
            if(gameObject.CompareTag("Arm") && !isDead)
            {
                ArmDeath();
            }
            else
            {
                foreach (GameObject obj in dependentObjects)
                {
                    Destroy(obj);
                }
                Destroy(this.gameObject);
            }
        }
    }

    public void ArmDeath()
    {
        transform.parent.GetComponent<Animator>().enabled = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        isDead = true;
        health = resetHealthValue;
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
