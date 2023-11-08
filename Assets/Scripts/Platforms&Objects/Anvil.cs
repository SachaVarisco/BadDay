using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
     public void OnCollisionEnter2D(Collision2D other)
   {
     if (other.gameObject.tag == "Finish"){
          SceneControl.Instance.anvil = true;
          other.gameObject.GetComponent<Dialogue>().autoDialogue = true;
        }
   }
}
