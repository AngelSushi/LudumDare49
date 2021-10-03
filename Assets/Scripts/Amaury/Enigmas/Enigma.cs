using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enigma : CoroutineSystem {
    public bool isAvailable;
    public bool isFinish;
    public bool isInProgress;
    public EnigmaController enigmaController;
    public GameObject[] sprites;
    public PlayerMovement player;

    private bool lastIsInProgress,lastIsFinish;

    public int actionEnd; // 0 = Ouverture Porte ; 1 = Changement Light
    public GameObject attachedObject;
    public WorldController worldController;
    
    void Update() {

        if(isInProgress && !lastIsInProgress) {
            OnBeginEnigma();
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

    public abstract void OnBeginEnigma();
    public abstract void OnEndEnigma();

}
