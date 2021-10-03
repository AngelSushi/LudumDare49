using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    
    public GameObject secondWorldParent;
    public bool isInFirstWorld;
    public GameObject ghostEffect;
    public Sprite openDoor;

    private bool lastWorld;

    void Update() {
        
        if(isInFirstWorld && !lastWorld) {
            secondWorldParent.SetActive(false);
            ghostEffect.SetActive(false);
        }

        if(!isInFirstWorld && lastWorld) {
            secondWorldParent.SetActive(true);
            ghostEffect.SetActive(true);
        }
        

        lastWorld = !isInFirstWorld;
    }
}
