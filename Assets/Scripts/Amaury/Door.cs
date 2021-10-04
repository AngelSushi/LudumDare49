using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour {
    public Sprite openDoor;
    public bool openByEnigma;

    public bool collide;
    private AudioSource Audio_Door;

    [SerializeField] private AudioClip audioDoor = null;

    private void Awake()
    {
        Audio_Door = GetComponent<AudioSource>();
    }
    void Update() {
        if(transform.gameObject.GetComponent<SpriteRenderer>().sprite == openDoor && transform.childCount > 0) {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
           

            
        }
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "Player") 
            collide = true;
        
    }

    private void OnCollisionExit2D(Collision2D hit) {
        if(collide)
            collide = false;
    }

    public void OnInteract(InputAction.CallbackContext e) {
        if(e.started && !openByEnigma && collide) {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
            collide = false;
            Audio_Door.PlayOneShot(audioDoor);

        }
    }
}
