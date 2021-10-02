using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpawner : MonoBehaviour {
    public string dialogName;
    public DialogController dialogController;

    private bool collide;

    void Update() {
        if(collide && Input.GetKeyDown(KeyCode.E)) {
            collide = false;
            Dialog dialog = dialogController.GetDialogByName(dialogName);
            dialogController.currentDialog = dialog;
            dialogController.isInDialog = true;
            Debug.Log("dialog: " + dialog);
            StartCoroutine(dialogController.ShowText(dialog.Content[0],dialog.Content.Length)); 
        }
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        Debug.Log("enter");
        if(hit.gameObject.tag == "Player" && !dialogController.isInDialog) {
            collide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(collide)
            collide = false;
    }
}
