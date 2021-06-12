using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool canDrag;
    public bool isAttached = false;
    private Vector3 enemyPartPosition;//position of the enemy body part
    private Rigidbody enemyBody;//enemy rigid body
    private float floorCheckDistance = 15f;
    private RaycastHit[] collisionCheck = new RaycastHit[1];
    // Start is called before the first frame update
    void Start()
    {
        enemyPartPosition = transform.position;  
        Debug.Log(enemyPartPosition);
        enemyBody = GetComponent<Rigidbody>();
        
    }
    void OnMouseDrag()
    {
        if (canDrag)
        {
            Debug.Log("Dragging");
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
            transform.position = cursorPosition;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Down");
        if (canDrag)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = (gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)));
            transform.DetachChildren();
        }
    }

    void OnMouseUp(){
       if(canDrag)
            AttachToPlayer();
    }

    public void AttachToPlayer(){
        string obj;
        if (canDrag)
            obj = "Bod";
        else
            obj = "NoPlayer";
        if (canDrag)
        {
            bool sweep = enemyBody.SweepTest(Vector3.down, out collisionCheck[0], floorCheckDistance);
            if(sweep != null && collisionCheck[0].transform != null){
                bool foundPlayer = false;
                if (collisionCheck[0].transform.name == obj && collisionCheck[0].distance != 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - collisionCheck[0].distance, transform.position.z);
                    foundPlayer = true; 
                }
                if (!foundPlayer){
                    transform.position = enemyPartPosition;
                }
                isAttached = foundPlayer;
            }
        }
    }

    public void CanDragPart()
    {
        canDrag = true;
    }

    public void NoDragPart()
    {
        canDrag = false;
    }
}
