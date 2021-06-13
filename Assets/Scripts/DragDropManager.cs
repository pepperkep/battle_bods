using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropManager : MonoBehaviour
{
    private Rigidbody enemyPart;
    private Vector3 originalPosition;
    private Vector2 mousePosition;
    private Vector2 offset;
    bool canAttach = true;
    Vector2 pos;
    private GameObject selectedObject;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
       mainCamera = Camera.main;
    }
    void Update()
    {
        pos = mainCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
    }
    
    public void onGrabPart(InputAction.CallbackContext context)
    {
        pos = mainCamera.ScreenToViewportPoint(mousePosition);
        if(context.ReadValue<float>() > 0.5f)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ViewportPointToRay(pos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag("Arm"))
                {
                    selectedObject = hit.transform.parent.gameObject;
                    offset = (Vector2)(mainCamera.ScreenToWorldPoint(mousePosition) - selectedObject.transform.position);
                    selectedObject.transform.SetParent(null);
                    Damageable damageComponent = selectedObject.GetComponentInChildren<Damageable>();
                    Damager damagerComponent = selectedObject.GetComponentInChildren<Damager>();
                    Rigidbody rb = selectedObject.GetComponentInChildren<Rigidbody>();
                    rb.isKinematic = true;
                    damageComponent.isEnemy = false;
                    damageComponent.isDead = false;
                    damagerComponent.damageEnemy = true;
                    damagerComponent.damagePlayer = false;
                }
            }
        }
        else
        {  
            RaycastHit[] hits;
            hits = Physics.RaycastAll(mainCamera.ViewportPointToRay(pos), 100.0f);

            bool onBod = false;
            GameObject bod = null;
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if(hit.transform.CompareTag("Player"))
                {
                    onBod = true;
                    bod = hit.transform.gameObject;
                }
            }

            if (onBod)
            {
                selectedObject.transform.SetParent(bod.gameObject.transform, true);
                selectedObject.GetComponent<Animator>().enabled = true;
            }
            selectedObject = null;
        }
    }

    public void onDragPart(InputAction.CallbackContext context)
    {
        if(selectedObject != null){
            Vector2 nextMousePosition = Mouse.current.position.ReadValue();
            Vector3 mouseMove = mainCamera.ScreenToWorldPoint(nextMousePosition) - mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition = nextMousePosition;
            Vector3 nextWorldPos = mainCamera.ScreenToWorldPoint(nextMousePosition);
            selectedObject.transform.position = new Vector3(nextWorldPos.x, nextWorldPos.y) - (Vector3)offset;
        }
    }
}
