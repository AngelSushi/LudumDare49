using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInventory : MonoBehaviour {
    
    public List<GameObject> possededObjects;

    private void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Object") {
            possededObjects.Add(hit.gameObject);
            hit.gameObject.SetActive(false);
        }
    }
}
