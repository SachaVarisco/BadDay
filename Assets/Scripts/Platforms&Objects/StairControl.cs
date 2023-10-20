using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairControl : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private int CountEntitiesWithTag(string tag)
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag(tag);
        int activeEntities = 0;
        foreach (GameObject entitie in entities)
        {
            if (entitie.activeSelf)
            {
                activeEntities++;
            }
        }
        return activeEntities;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (CountEntitiesWithTag("Bone") <= 0 && Input.GetButtonDown("Jump")){
            if (other.CompareTag("Player")){
                SceneControl.Instance.stair = true;
                //canvas.GetComponent<SceneTransition>().ChangeScene("FirstFloor");
                SceneManager.LoadScene("FirstFloor");
            }
        }  
    }
}
