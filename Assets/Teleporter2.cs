using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    public GameObject Player2;
    public GameObject TeleportTo2;
    public GameObject StartTeleporter2;
    public Animator fadeSystem2;
    public PlayerMovement movePlayer2;

    private int speedLost = 5;
    private float speedDuration = 1f;

    private AudioSource Audio_Tp2;

    [SerializeField] private AudioClip audioTp2 = null;

    private void Awake()
    {
        Audio_Tp2 = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            StartCoroutine(TimeToTeleport());

            movePlayer2.moveSpeed -= speedLost;
            StartCoroutine(RecupSpeed(speedLost, speedDuration));

        }


        if (collision.gameObject.CompareTag("SecondTeleporter"))
        {

            StartCoroutine(TimeToTeleport2());

            movePlayer2.moveSpeed -= speedLost;
            StartCoroutine(RecupSpeed(speedLost, speedDuration));
        }




    }


    public IEnumerator RecupSpeed(int speedLost, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        movePlayer2.moveSpeed += speedLost;


    }

    public IEnumerator TimeToTeleport()
    {

        Audio_Tp2.PlayOneShot(audioTp2);
        fadeSystem2.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        Player2.transform.position = TeleportTo2.transform.position;



    }

    public IEnumerator TimeToTeleport2()
    {
        Audio_Tp2.PlayOneShot(audioTp2);
        fadeSystem2.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        Player2.transform.position = StartTeleporter2.transform.position;

    }

}