using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairControl : MonoBehaviour
{
    private int CountEntitiesWithTag(string tag)
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag(tag);
        return entities.Length;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CountEntitiesWithTag("Bone") <= 0){
            if (other.CompareTag("Player")){
                SceneManager.LoadScene("Level1");
            }
        }
          
    }
}
