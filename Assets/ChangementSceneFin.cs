using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementSceneFin : MonoBehaviour
{
    public string sceneToGo;
    public bool isFinished = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFinished)
        {
            SceneManager.LoadScene(sceneToGo);
        }
    }
}
