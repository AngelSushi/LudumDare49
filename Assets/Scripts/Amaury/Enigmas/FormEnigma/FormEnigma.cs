using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormEnigma : Enigma {
    
    public int maxFormCount;
    public int maxCodeSize;
    public Dictionary<int,FormType> secretCode;
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

        isFinish = HasFinish();
    }

    public bool HasFinish() {
        foreach(int code in findCode) {
            if(code == -1)
                return false;
        }

        return true;
    }
}
