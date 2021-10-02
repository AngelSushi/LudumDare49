using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortRespawn : MonoBehaviour
{

    private Transform target;
    public Animator fadeSystem;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            StartCoroutine(loadPlayerSpawn());
            col.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;

        }
    }

    public IEnumerator loadPlayerSpawn()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
    }
 

}
