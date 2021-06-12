using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int keyNumber = 1;
    private Animator anim;
    void Start()
    {
       anim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void OnFire(bool value) 
    {
       //anim.SetBool("FireWeapon", context.ReadValue<float>() > 0.5f); 
       anim.SetBool("FireWeapon", value); 
    }
}
