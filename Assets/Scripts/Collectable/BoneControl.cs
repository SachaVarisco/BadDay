using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneControl : MonoBehaviour
{
   [SerializeField] private AudioClip audio;
   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player")){
         SceneControl.Instance.PlaySound(audio);
         SceneControl.Instance.PushName(gameObject.name);
         other.gameObject.GetComponent<PLayerLifeControl>().RestLife();
         gameObject.SetActive(false);
      }
   }
}
