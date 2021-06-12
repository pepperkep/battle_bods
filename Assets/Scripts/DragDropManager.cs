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
    private Rigidbody2D playerBody;//player rigid body
    private float floorCheckDistance = 15f;
    // Start is called before the first frame update
    void Start()
    {
        enemyPartPosition = transform.position;  
        playerBody = GetComponent<Rigidbody2D>()
    }
    void OnMouseDrag()
    {
        if (canDrag)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
            transform.position = cursorPosition;
        }
    }

     void OnMouseDown()
    {
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
            obj = "Player";
        else
            obj = "Player1";
        if (canDrag)
        {
            int hitNum = platformBody.Cast(Vector2.down, collisionCheck, floorCheckDistance);
            if(collisionCheck[0] != null && collisionCheck[0].transform != null){
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
