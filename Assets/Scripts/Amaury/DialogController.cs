using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[System.Serializable]
public class Dialog {

    public string Author;
    public string Name;
    public string[] Content;
    public string Texture;
    public string Tag;
    public string Answer;
    public bool NeedInteraction;
    public bool isFinish;
}

[System.Serializable]
 public class DialogArray {
    public Dialog[] dialogs;
}

public class DialogController : MonoBehaviour {
    public float speed,accelerate;    
    public bool isInDialog;
    public Text text;
    public Text nextObj;
    public Image head;
    public GameObject dialogObj;
    public DialogArray dialogs;
    public bool finish = false;
    public Dialog currentDialog;

    private bool nextPage;
    private int index = 0;
    private float originalSpeed;

    private int answer = 0;
    
    public TextAsset dialogsFile;  

    void Start() {
        originalSpeed = speed;
        dialogs = JsonUtility.FromJson<DialogArray>(dialogsFile.text);
    }

    public void OnInteract(InputAction.CallbackContext e) { 
        Debug.Log("enter");
        if(e.started && isInDialog) {
            if( !nextPage) 
                AccelerateDialog(accelerate);
            if(nextPage && !finish) {
                nextPage = false;
                nextObj.gameObject.SetActive(false);
                StartCoroutine(ShowText(currentDialog.Content[index],currentDialog.Content.Length));
            }

            if(finish) {
                if(currentDialog.Answer != null) {
                    index = 0;
                    finish = false;
                    currentDialog = GetDialogByName(currentDialog.Answer);
                    StartCoroutine(ShowText(currentDialog.Content[0],currentDialog.Content.Length)); 
                }
                else 
                    EndDialog();
            } 
        }   

        if(e.canceled) 
            AccelerateDialog(originalSpeed);   
                   
    }

    void AccelerateDialog(float accelerate) {
        this.speed = accelerate;
    }

    public IEnumerator ShowText(string displayText,int length) {
        nextPage = false;
        dialogObj.SetActive(true);
        text.gameObject.SetActive(true);
        nextObj.gameObject.SetActive(false);
        head.sprite = Resources.Load<Sprite>(currentDialog.Texture);

        for(int i = 1;i<displayText.Length;i++) {
           yield return new WaitForSeconds(speed);
           text.text = displayText.Substring(0,i);
       }
        
        nextObj.gameObject.SetActive(true);

        if(length > 1 && index < length) {
            nextPage = true;
            index ++;
        }

        if((length > 1 && index == length) || (length == 1)) 
            finish = true;
    }

    void EndDialog() {
        dialogObj.SetActive(false);
        nextObj.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        nextPage = false;
        index = 0;
        answer = 0;
        text.text = "";
        isInDialog = false;
        finish = false;
        currentDialog.isFinish = true;
    }

    public Dialog GetDialogByName(string name) {
         foreach (var dialog in dialogs.dialogs) {
            if(dialog.Name == name) {
                return dialog;
            }
        }       

        return null;  
    }

}
