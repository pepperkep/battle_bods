using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EnterToStart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
