using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigma : CoroutineSystem {
    public bool isAvailable;
    public bool isFinish;
    public bool isInProgress;
    public EnigmaController enigmaController;
    public GameObject[] sprites;
    public PlayerMovement player;

    private bool lastIsInProgress,lastIsFinish;

    void Update() {

        if(isInProgress && !lastIsInProgress) {
            foreach(GameObject sprite in sprites) 
                sprite.SetActive(true);
        }

        if(isFinish && !lastIsFinish) {
            player.isInEnigma = false;
            foreach(GameObject sprite in sprites)
                sprite.SetActive(false);
        }

        lastIsInProgress = isInProgress;
        lastIsFinish = isFinish;
    }

}
