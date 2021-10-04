using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public Sprite openDoor;

    void Update() {
        if(transform.gameObject.GetComponent<SpriteRenderer>().sprite == openDoor && transform.childCount > 0) 
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
