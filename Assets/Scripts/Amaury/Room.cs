using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    private bool collide;

    void Update() {
        transform.gameObject.GetComponent<SpriteRenderer>().enabled = !collide;

        for(int i = 0;i<transform.childCount;i++) 
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = !collide;
    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player")
            collide = true;
    }

    private void OnTriggerExit2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player")
            collide = false;
    }
}
