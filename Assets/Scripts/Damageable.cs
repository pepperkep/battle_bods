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
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        Damager hurtbox = col.gameObject.GetComponent<Damager>();
        if(hurtbox != null && ((hurtbox.damageEnemey && isEnemy) || (hurtbox.damagePlayer && !isEnemy)))
            health -= hurtbox.damage;
    }
}
