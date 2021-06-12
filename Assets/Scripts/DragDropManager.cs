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
    // Start is called before the first frame update
    void Start()
    {
       enemyPart = gameObject.GetComponent<Rigidbody>(); 
        
    }
    public void Update()
    {
       
       
    }
    //For when you click on the part the script is attached to
    private void onGrabPart(InputAction.CallbackContext context){
        if(isDraggable){
        Debug.Log("Found enemy part!");
        originalPosition = transform.position;  
        Debug.Log(originalPosition);
        }

    }
    //For dragging the part based on the change in location of the mouse
    private void onDragPart(InputAction.CallbackContext context){
    if(isDraggable){
    mouseMove = context.ReadValue<Vector2>();
    enemyPart.MovePosition((enemyPart.position + ((Vector3)(mouseMove.x * Vector2.right * Time.fixedDeltaTime * moveSpeed))));
    }
    }
    //For making the part a child object of the player's body when it collides with the player's collider
    private void OnCollisionEnter(Collision other) {
         if (other.gameObject.name == "Bod"){
             this.gameObject.transform.parent = other.gameObject.transform;
         }
    }
    
}
