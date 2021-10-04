using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FormCollision : MonoBehaviour {

    public bool isMooving;
    public bool isPlaced;
    private bool collide;
    public Vector3 originalPos;
    public FormType type;
    public FormEnigma enigma;
    public TakeObject myObj;
    
    private Vector3 cursorPos,lastCursorPos;

    void Start() {
        originalPos = transform.position;
    }

    void Update() {
        if(enigma.isInProgress) {
            Vector3 cursor = Mouse.current.position.ReadValue();
            cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(cursor.x,cursor.y,Camera.main.nearClipPlane));

            if(isMooving) 
                transform.position = cursorPos;
            else if(!isMooving && !isPlaced && !collide) 
                transform.position = originalPos;         
        
            lastCursorPos = cursorPos;
        }
    }

    public void OnClick(InputAction.CallbackContext e) {
        if(e.started && enigma.isInProgress) {
            if(transform.position.x - 0.5f < cursorPos.x && transform.position.x + 0.5f > cursorPos.x) {
                if(transform.position.y - 0.5f < cursorPos.y && transform.position.y + 0.5f > cursorPos.y) 
                    isMooving = true; 
            }   
            
        }

        if(e.canceled && enigma.isInProgress) 
            isMooving = false;    
    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "ResultArea" && enigma.isInProgress) {
            if(!isMooving && !isPlaced) {
                int index = hit.gameObject.transform.GetSiblingIndex();
                Vector3 newPosition = hit.gameObject.transform.position;
                newPosition.z = -2;
                transform.position = newPosition;
                isPlaced = true;
                if(enigma.obtainingType == FormEnigma.ObtaningType.FORM) 
                    enigma.UpdateFindCode(index,(int)type);
                else if(enigma.obtainingType == FormEnigma.ObtaningType.OBJECT)
                    enigma.UpdateFindCode(index,myObj.id);
            }
            else if(isMooving) 
                collide = true;     
        }
    }

    private void OnCollisionExit2D(Collision2D hit) {
        if(hit.gameObject.tag == "ResultArea" && enigma.isInProgress) {
            if(collide)
                collide = false;
            if(isPlaced)
                isPlaced = false;
        }
    }
}
