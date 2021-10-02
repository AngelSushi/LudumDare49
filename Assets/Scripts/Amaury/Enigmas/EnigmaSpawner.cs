using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaSpawner : MonoBehaviour {
    
    public Enigma enigma;
    public PlayerMovement player;

    private bool collide;

    void Update() {

        if(collide && Input.GetKeyDown(KeyCode.E)) {
            enigma.isInProgress = true;
            player.isInEnigma = true;
        }
    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player" && !enigma.isFinish && enigma.isAvailable && !enigma.isInProgress) 
            collide = true;
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(collide)
            collide = false;
    }
}

