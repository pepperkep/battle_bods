using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerArms : MonoBehaviour
{

    public List<Weapon> triggerArms;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnArm1(InputAction.CallbackContext context) 
    {
       FireAllWithNum(1, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm2(InputAction.CallbackContext context) 
    {
       FireAllWithNum(2, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm3(InputAction.CallbackContext context) 
    {
       FireAllWithNum(3, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm4(InputAction.CallbackContext context) 
    {
       FireAllWithNum(4, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm5(InputAction.CallbackContext context) 
    {
       FireAllWithNum(5, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm6(InputAction.CallbackContext context) 
    {
       FireAllWithNum(6, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm7(InputAction.CallbackContext context) 
    {
       FireAllWithNum(7, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm8(InputAction.CallbackContext context) 
    {
       FireAllWithNum(8, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm9(InputAction.CallbackContext context) 
    {
       FireAllWithNum(9, context.ReadValue<float>() > 0.5f); 
    }

    public void OnArm10(InputAction.CallbackContext context) 
    {
       FireAllWithNum(0, context.ReadValue<float>() > 0.5f); 
    }

    // Update is called once per frame
    void FireAllWithNum(int num, bool value)
    {
        foreach (Weapon arm in triggerArms)
        {
            if(arm.keyNumber == num)
                arm.OnFire(value);
        }
    }

    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Weapon weaponComponent = transform.GetChild(i).GetComponentInChildren<Weapon>();
            if(weaponComponent != null && !triggerArms.Contains(weaponComponent))
            {
                triggerArms.Add(weaponComponent);
            }
        }
    }
}
