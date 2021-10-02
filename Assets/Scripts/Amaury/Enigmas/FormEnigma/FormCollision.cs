using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormCollision : MonoBehaviour {

    public bool isMooving;
    public bool isPlaced;
    private bool collide;
    public Vector3 originalPos;
    public FormType type;
    public FormEnigma enigma;

    void Start() {
        originalPos = transform.position;
    }

    void Update() {
        if(enigma.isInProgress) {
            if(isMooving) {
                Vector3 cameraPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
                transform.position = cameraPos;
            }
            else if(!collide) {
                transform.position = originalPos;
                collide = false;
            }
        }
    }

    void OnMouseDown() {
        if(enigma.isInProgress) 
            isMooving = true;
    }

    void OnMouseUp() {
        if(enigma.isInProgress) 
            isMooving = false;
    }

    private void OnCollisionStay2D(Collision2D hit) {
        if(hit.gameObject.tag == "ResultArea" && enigma.isInProgress) {
            if(!isMooving && !isPlaced) {
                int index = hit.gameObject.transform.GetSiblingIndex();
                Vector3 newPosition = hit.gameObject.transform.position;
                newPosition.z = -2;
                transform.position = newPosition;
                isPlaced = true;
                enigma.UpdateFindCode(index,(int)type);
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
