using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FormEnigma : Enigma {
    
    public int maxFormCount;
    public int maxCodeSize;
    public float timeToWait;
    public Dictionary<int,FormType> secretCode;
    public List<FormCollision> formCollisions;
    public int[] findCode = {-1,-1,-1};

    void Start() {
        secretCode = new Dictionary<int,FormType>();

        for(int i = 0;i<maxCodeSize;i++) {
            int random = -1;

            while(random == -1 || AlreadyInCode(random))
                random = Random.Range(0,maxFormCount);
            
           // secretCode[i] = random;
           secretCode.Add(random,(FormType)random);
        }

        foreach(int i in secretCode.Keys) {
            Debug.Log("index: " + i + " type: " + secretCode[i]);
        }
    }

    private bool AlreadyInCode(int code) {
        foreach(int sCode in secretCode.Keys) {
            if(sCode == code)
                return true;
        }
        return false;
    }

    public void UpdateFindCode(int index,int value) {
        findCode[index] = value;

        if(HasComplete()) {
            RunDelayed(timeToWait,() => {
                isFinish = IsFinish();
                if(!isFinish) {
                    foreach(int type in findCode) {
                        GameObject targetForm = GetObjectByType(type);
                        targetForm.transform.position = targetForm.GetComponent<FormCollision>().originalPos;
                    }

                    findCode = new int[3]{-1,-1,-1};
                }
            });
        }
    }
    public bool HasComplete() {
        foreach(int code in findCode) {
            if(code == -1)
                return false;
        }

        return true;
    }

    public bool IsFinish() {
        for(int i = 0;i<findCode.Length;i++) {
            if(findCode[i] != (int)secretCode.Values.ToArray()[i])
                return false;
        }

        return true;
    }

    private GameObject GetObjectByType(int type) {
        foreach(FormCollision c in formCollisions) {
            if((int)c.type == type)
                return c.gameObject;
        }

        return null;
    }
}
