using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public bool allBone;
    void Update()
    {
        if(allBone){
            gameObject.GetComponent<Dialogue>().autoDialogue = true;
            allBone = false;
        }
    }
}
