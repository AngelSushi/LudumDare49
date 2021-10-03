using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogSpawner : MonoBehaviour {
    private string dialogName;
    public DialogController dialogController;

    private bool collide;

    private void OnTriggerEnter2D(Collider2D hit) {
        if(!dialogController.isInDialog) {
            foreach(Dialog dialog in dialogController.dialogs.dialogs) {
                if(hit.gameObject.tag == dialog.Tag) {
                    collide = true;
                    dialogName = dialog.Name;
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
