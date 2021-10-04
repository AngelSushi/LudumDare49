using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldController : MonoBehaviour {
    
    public GameObject secondWorldParent;
    public bool isInGhost;
    public GameObject ghostEffect;

    private bool lastWorld;
    private AudioSource Audio_Ghost;

    [SerializeField] private AudioClip audioGhost = null;

    private void Awake()
    {
        Audio_Ghost = GetComponent<AudioSource>();
    }
    void Update() {
        
        if(!isInGhost && !lastWorld) {
            secondWorldParent.SetActive(false);
            ghostEffect.SetActive(false);
        }

        if(isInGhost && lastWorld) {
            secondWorldParent.SetActive(true);
            ghostEffect.SetActive(true);
        }
        

        lastWorld = !isInGhost;
    }

    public void OnGhost(InputAction.CallbackContext e) {
        if(e.started)  {
            isInGhost = !isInGhost;
            Audio_Ghost.PlayOneShot(audioGhost);
        }
    }
}
