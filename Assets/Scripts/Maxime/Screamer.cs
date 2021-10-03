using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{

    public GameObject screamer;
    public void OnPlayerScream()
    {

        screamer.SetActive(true);

        Debug.Log(screamer);
    }

    
}
