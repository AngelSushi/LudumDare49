using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressionTable : MonoBehaviour
{

    private AudioSource Audio_pressionTable;

    [SerializeField] private AudioClip audiopressionTable = null;

    private void Awake()
    {
        Audio_pressionTable = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Audio_pressionTable.PlayOneShot(audiopressionTable);
        }
    }
}
