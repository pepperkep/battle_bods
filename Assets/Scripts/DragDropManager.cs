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
       DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        pos = mainCamera.ScreenToViewportPoint(Mouse.current.position.ReadValue());
    }
    
    public void onGrabPart(InputAction.CallbackContext context)
    {
        mainCamera = Camera.main;
        pos = mainCamera.ScreenToViewportPoint(mousePosition);
        Vector2 nextMousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseMove = mainCamera.ScreenToWorldPoint(nextMousePosition) - mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition = nextMousePosition;
        Vector3 nextWorldPos = mainCamera.ScreenToWorldPoint(nextMousePosition);
        if(context.ReadValue<float>() > 0.5f)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ViewportPointToRay(pos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag("Arm") && hit.transform.parent.parent == null)
                {
                    selectedObject = hit.transform.parent.gameObject;
                    selectedObject.transform.SetParent(null, true);
                    Damageable damageComponent = selectedObject.GetComponentInChildren<Damageable>();
                    Damager damagerComponent = selectedObject.GetComponentInChildren<Damager>();
                    Rigidbody rb = selectedObject.GetComponentInChildren<Rigidbody>();
                    rb.isKinematic = true;
                    damageComponent.isEnemy = false;
                    damageComponent.isDead = false;
                    damageComponent.currentHealth = damageComponent.health;
                    Vector3 tmp = selectedObject.transform.GetChild(0).transform.position;
                    selectedObject.transform.position = new Vector3(nextWorldPos.x, nextWorldPos.y, selectedObject.transform.position.z);
                    selectedObject.transform.GetChild(0).position = tmp;
                    offset = (Vector2)(mainCamera.ScreenToWorldPoint(mousePosition) - selectedObject.transform.position);
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
                selectedObject.transform.position = new Vector3(nextWorldPos.x, nextWorldPos.y) - (Vector3)offset;
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
