using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    private void Start()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
            {
            enemy1.SetActive(true);
            enemy2.SetActive(true);


        }

        
    }

   




}
