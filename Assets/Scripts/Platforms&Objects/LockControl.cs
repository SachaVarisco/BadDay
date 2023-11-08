using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockControl : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player"){
      foreach (string word in SceneControl.Instance.keyName){
        if (gameObject.name == word)
        {
          switch (gameObject.name)
          {
              case "Green":
                GameObject door = GameObject.Find("AtticDoor");
                door.GetComponent<StairControl>().enabled = true;
                  break;
              /*case "Blue":
                  GameObject door1 = GameObject.Find("BackDoor");
                  door1.GetComponent<BackDoor>().enabled = true;
                  break;*/
              case "Red":
                  GameObject door2 = GameObject.Find("Cage");
                  door2.SetActive(false);
                  SceneControl.Instance.lockName.Add(door2.name);
                  break;
          
              default:
                  break;
          }
          SceneControl.Instance.lockName.Add(gameObject.name);
          gameObject.SetActive(false);
        }
      }
    }
  }
}
