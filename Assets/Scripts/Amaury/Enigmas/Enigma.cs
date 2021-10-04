using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Enigma : CoroutineSystem {
    public bool isAvailable;
    public bool isFinish;
    public bool isInProgress;
    public EnigmaController enigmaController;
    public GameObject[] sprites;
    public PlayerMovement player;

    public bool lastIsInProgress,lastIsFinish;

    public int actionEnd; // 0 = Ouverture Porte ; 1 = Changement Light
    public GameObject attachedObject;
    public GameObject cursor;

    public GameObject background;
    public Sprite spriteBackground;

    private bool open;

    public override void Update() {

        if(isInProgress && !lastIsInProgress ) {
            OnBeginEnigma();
            background.GetComponent<SpriteRenderer>().sprite = spriteBackground;
            foreach(GameObject sprite in sprites) 
                sprite.SetActive(true);    
        }

        if(isFinish && !lastIsFinish) {
            OnEndEnigma();
            player.isInEnigma = false;
            foreach(GameObject sprite in sprites)
                sprite.SetActive(false);
        }

        lastIsInProgress = isInProgress;
        lastIsFinish = isFinish;
    }

    public void OnQuit(InputAction.CallbackContext e) {
        if(e.canceled && isInProgress) {
            isInProgress = false;
            player.isInEnigma = false;
            foreach(GameObject sprite in sprites)
                sprite.SetActive(false);
        }
    }
    public abstract void OnBeginEnigma();
    public abstract void OnEndEnigma();

}
