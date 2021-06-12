using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropManager : MonoBehaviour
{
    private Rigidbody enemyPart;
    private Vector3 originalPosition;
    private Vector2 mouseMove;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isDraggable;
    bool isGrabbed = false;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
       enemyPart = gameObject.GetComponent<Rigidbody>(); 
        
    }
    void FixedUpdate()
    {
        
             pos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            //Debug.Log(pos);
            
            
            
        
    }
    
    public void onGrabPart(InputAction.CallbackContext context){
        if(isDraggable){
        isGrabbed = true;
        Debug.Log("Found enemy part!");
        originalPosition = transform.position;  
        Debug.Log(originalPosition);
        }

    }

    public void onDragPart(InputAction.CallbackContext context){
    if(isDraggable && isGrabbed){
    mouseMove = context.ReadValue<Vector2>();
    enemyPart.MovePosition((enemyPart.position + ((Vector3)(mouseMove))));
    
    }
    }

    public void OnCollisionEnter(Collision other) {
         if (other.gameObject.name == "Bod"){
             this.gameObject.transform.parent = other.gameObject.transform;
         }
    }
    
}
