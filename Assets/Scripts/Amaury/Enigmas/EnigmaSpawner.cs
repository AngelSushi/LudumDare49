using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnigmaSpawner : MonoBehaviour {
    
    public Enigma enigma;
    public PlayerMovement player;

    public bool collide;

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player" && !enigma.isFinish && enigma.isAvailable && !enigma.isInProgress) 
            collide = true;
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(collide)
            collide = false;
    }

    public void OnInteract(InputAction.CallbackContext e) {
        if(e.started && collide) {
            enigma.isInProgress = true;
            player.isInEnigma = true;
            collide = false;
        }
    }
}

