using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockControl : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
   {
        if (other.gameObject.tag == "Player" && SceneControl.Instance.redKey){
          gameObject.SetActive(false);
          SceneManager.LoadScene("Credits");
        }
   }
}
