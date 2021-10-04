using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NextScene : MonoBehaviour
{

    public Transform balise;
    bool col;
    public Collider2D collision;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        Debug.Log("TOUCHE");
        if (coli.gameObject.CompareTag("Player"))
        {
            col = true;
            collision = coli;
            
        }
    }
    public void OnInteract(InputAction.CallbackContext e)
    {

        if (e.started)
        {

            collision.gameObject.transform.position = balise.position;
        }
    }
}
