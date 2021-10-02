using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigma : MonoBehaviour {
    public bool isAvailable;
    public bool isFinish;
    public bool isInProgress;
    public EnigmaController enigmaController;
    public GameObject[] sprites;

    private bool lastIsInProgress,lastIsFinish;

    void Update() {

        if(isInProgress && !lastIsInProgress) {
            foreach(GameObject sprite in sprites) 
                sprite.SetActive(true);
        }

        if(isFinish && !lastIsFinish) {
            foreach(GameObject sprite in sprites)
                sprite.SetActive(false);
        }

        lastIsInProgress = isInProgress;
        lastIsFinish = isFinish;
    }

}
