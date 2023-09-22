using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketControl : MonoBehaviour
{
     private string actualScene;
     private void Start() {
          actualScene = SceneManager.GetActiveScene().name;
     }
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D other)
   {
     if (other.gameObject.tag == "Player"){
          RestartScene();
     }
   }

   public void RestartScene(){   
     SceneManager.LoadScene(actualScene);
   }
}
