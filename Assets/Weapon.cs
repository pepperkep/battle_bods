using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
       anim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void OnFire(InputAction.CallbackContext context) 
    {
       anim.SetBool("FireWeapon", context.ReadValue<float>() > 0.5f); 
    }
}
