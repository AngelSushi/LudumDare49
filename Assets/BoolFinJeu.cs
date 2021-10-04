using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolFinJeu : MonoBehaviour
{
    public GameObject triggerSceneFin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerSceneFin.GetComponent<ChangementSceneFin>().isFinished = true;
    }
}
