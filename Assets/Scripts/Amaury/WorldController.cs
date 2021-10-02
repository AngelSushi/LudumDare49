using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    
    public GameObject firstWorldParent;
    public GameObject secondWorldParent;
    public bool isInFirstWorld;

    private bool lastWorld;

    void Update() {
        
        if(isInFirstWorld && !lastWorld) {
            firstWorldParent.SetActive(true);
            secondWorldParent.SetActive(false);
        }

        if(!isInFirstWorld && lastWorld) {
            firstWorldParent.SetActive(false);
            secondWorldParent.SetActive(true);
        }
        

        lastWorld = !isInFirstWorld;
    }
}
