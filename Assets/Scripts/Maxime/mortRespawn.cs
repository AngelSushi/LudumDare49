using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortRespawn : MonoBehaviour
{
    public GameObject screamer;
    private Transform target;
    public Animator fadeSystem;
    public Animator Player;

    public void OnPlayerScream()
    {

        screamer.SetActive(true);

        Debug.Log(screamer);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            OnPlayerScream();
            StartCoroutine(loadPlayerSpawn());
            StartCoroutine(TimeToDie(col));
            StartCoroutine(TimeToScream());

            Player.SetTrigger("DiePlayer");
        }
     
    }
   
    public IEnumerator loadPlayerSpawn()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator TimeToDie(Collider2D col)
    {
        yield return new WaitForSeconds(1f);
        col.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
    }

    public IEnumerator TimeToScream()
    {
        
        yield return new WaitForSeconds(0.5f);
        OnPlayerScream();
        screamer.SetActive(false);
    }
}
