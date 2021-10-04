using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortRespawn : MonoBehaviour
{
    public GameObject ObjectToDestroy;
   
    private Transform target;
    
   
    public Animator Enemy;

    private AudioSource Audio_SCREAM;

    [SerializeField] private AudioClip audioSCREAM = null;

    private void Awake()
    {
        Audio_SCREAM = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Audio_SCREAM.PlayOneShot(audioSCREAM);
           
            Enemy.SetBool("DieEnemy",true);



            GameObject.Destroy(ObjectToDestroy, 2.0f);
        }
     
    }
   
  



}
