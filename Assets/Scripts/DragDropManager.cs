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
    private bool isDraggable;
    // Start is called before the first frame update
    void Start()
    {
       enemyPart = gameObject.GetComponent<Rigidbody>(); 
        
    }
    public void Update()
    {
       
       
    }

    private void onGrabPart(InputAction.CallbackContext context){
        if(isDraggable){
        Debug.Log("Found enemy part!");
        originalPosition = transform.position;  
        Debug.Log(originalPosition);
        }

    }

    private void onDragPart(InputAction.CallbackContext context){
    if(isDraggable){
    mouseMove = context.ReadValue<Vector2>();
    enemyPart.MovePosition((enemyPart.position + ((Vector3)(mouseMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed))));
    }
    }

    private void OnCollisionEnter(Collision other) {
         if (other.gameObject.name == "Bod"){
             this.gameObject.transform.parent = other.gameObject.transform;
         }
    }
    
}
