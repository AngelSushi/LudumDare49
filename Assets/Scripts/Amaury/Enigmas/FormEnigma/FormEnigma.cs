using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class FormEnigma : Enigma {
    
    public enum ObtaningType {
        FORM,
        OBJECT
    }

    public int enigmaID;
    public int maxFormCount;
    public int maxCodeSize;
    public float timeToWait;
    public ObtaningType obtainingType;
    public List<int> objectsId;
    public List<int> codeId;

    private Dictionary<int,FormType> secretCode;
    private List<FormCollision> formCollisions;
    public int[] findCode;
    public bool isMovingObj;

    private Vector2 moveCursor;

    void Start() {
        findCode = new int[maxCodeSize];

        for(int i = 0;i<maxCodeSize;i++)
            findCode[i] = -1;

        if(obtainingType == ObtaningType.FORM) {
            secretCode = new Dictionary<int,FormType>();

            for(int i = 0;i<maxCodeSize;i++) {
                int random = -1;

                while(random == -1 || AlreadyInCode(random))
                    random = Random.Range(0,maxFormCount);
                
            // secretCode[i] = random;
                secretCode.Add(random,(FormType)random);
            }

            foreach(int i in secretCode.Keys) {
                Debug.Log("index: " + i + " type: " + secretCode[i]);
            }
        }
    }

    private bool AlreadyInCode(int code) {
        foreach(int sCode in secretCode.Keys) {
            if(sCode == code)
                return true;
        }
        return false;
    }

    public override void OnBeginEnigma() {
        Cursor.visible = true;
        if(obtainingType == ObtaningType.OBJECT) 
           ChangeSpriteState(true);    
    }

    public override void OnEndEnigma() {
        Cursor.visible = false;
        isInProgress = false;
        if(obtainingType == ObtaningType.OBJECT) 
           ChangeSpriteState(true); 

        if(actionEnd == 0) {
            attachedObject.GetComponent<BoxCollider2D>().enabled = false;
            attachedObject.GetComponent<SpriteRenderer>().sprite = attachedObject.GetComponent<Door>().openDoor;
        }
        else if(actionEnd == 1) 
            attachedObject.GetComponent<Light>().intensity = 1;
        
    }

    private void ChangeSpriteState(bool state) {
         foreach(GameObject obj in player.inventory.possededObjects) {
            TakeObject myObject = obj.GetComponent<TakeObject>();
            if(myObject.enigmaID == enigmaID && objectsId.Contains(myObject.id))
                myObject.relatedSprite.SetActive(true);
        }
    }
  

    public void UpdateFindCode(int index,int value) {
        findCode[index] = value;

        if(HasComplete()) {
            RunDelayed(timeToWait,() => {
                isFinish = IsFinish();
                if(!isFinish) {
                    for(int i = 0;i<transform.GetChild(1).childCount;i++) 
                        transform.GetChild(1).GetChild(i).position = transform.GetChild(1).GetChild(i).gameObject.GetComponent<FormCollision>().originalPos;
                    
                    findCode = new int[maxCodeSize];
                    for(int i = 0;i<maxCodeSize;i++)
                        findCode[i] = -1;
                }
                
            });
        }
    }
    public bool HasComplete() {
        foreach(int code in findCode) {
            if(code == -1)
                return false;
        }

        return true;
    }

    public bool IsFinish() {
        if(obtainingType == ObtaningType.FORM) {
            for(int i = 0;i<findCode.Length;i++) {
                if(findCode[i] != (int)secretCode.Values.ToArray()[i])
                    return false;
            }
        }
        else if(obtainingType == ObtaningType.OBJECT) {
            for(int i = 0;i<findCode.Length;i++) {
                if(findCode[i] != codeId[i])
                    return false;
            }
        }

        return true;
    }

    public void OnMoveCursor(InputAction.CallbackContext e) {
        if((e.started || e.performed) && isInProgress && !isFinish && isAvailable) {
            moveCursor = e.ReadValue<Vector2>();
            Cursor.visible = false;
            cursor.SetActive(true);
            Vector2 pos = new Vector2(transform.position.x,transform.position.y);
            cursor.transform.Translate(moveCursor * 25 * Time.deltaTime);
        }
    }

    
}
