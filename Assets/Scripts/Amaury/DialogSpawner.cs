using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogSpawner : MonoBehaviour {
    private string dialogName;
    public DialogController dialogController;

    private bool collide;

    private void OnTriggerStay2D(Collider2D hit) {
        if(!dialogController.isInDialog) {
            foreach(Dialog listDialog in dialogController.dialogs.dialogs) {
                if(!listDialog.isFinish && hit.gameObject.tag == listDialog.Tag) {
                    if(listDialog.NeedInteraction) {
                        collide = true;
                        dialogName = listDialog.Name;
                    }
                    else {
                        collide = false;
                        Dialog dialog = dialogController.GetDialogByName(listDialog.Name);
                        dialogController.currentDialog = dialog;
                        dialogController.isInDialog = true;
                        StartCoroutine(dialogController.ShowText(dialog.Content[0],dialog.Content.Length));                }
                    
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(collide)
            collide = false;
    }

    public void OnInteract(InputAction.CallbackContext e) {
        if(e.started) {
            if(collide) {
                collide = false;
                Dialog dialog = dialogController.GetDialogByName(dialogName);
                dialogController.currentDialog = dialog;
                dialogController.isInDialog = true;
                StartCoroutine(dialogController.ShowText(dialog.Content[0],dialog.Content.Length));
            }
        }
    }
}
