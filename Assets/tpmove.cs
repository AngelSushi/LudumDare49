using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpmove : MonoBehaviour
{
    public GameObject player;

    public GameObject balise1;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = balise1.transform.position;
        }
    }
}
