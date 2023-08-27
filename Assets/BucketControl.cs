using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
   {
    if (other.gameObject.tag == "Player"){
        RestartScene();
    }
   }

   public void RestartScene(){   
        SceneManager.LoadScene("Level1");
   }
}
