using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poignee : MonoBehaviour {
    
    public GameObject linkDoor;


    private void OnTriggerEnter2D(Collider2D hit) { 
        if(hit.gameObject.tag == "Player") {
            linkDoor.GetComponent<SpriteRenderer>().sprite = linkDoor.GetComponent<Door>().openDoor;
        }
    }   
}
