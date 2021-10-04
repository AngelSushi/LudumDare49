using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour {
    public int enigmaID;
    public int id;
    public GameObject relatedSprite;
    public bool isInGhost;
    public WorldController worldController;

    private Vector3 originalPos;

    void Start() {
        originalPos = transform.position;
    }

    void Update() {

        if(isInGhost && worldController.isInGhost && transform.position != originalPos)
            transform.position = originalPos;
    }
}
