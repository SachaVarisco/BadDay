using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.gameObject.tag == "Player"){
            SceneControl.Instance.PlaySound(audio);
            SceneControl.Instance.keyName.Add(gameObject.name);
            SceneControl.Instance.keys.sprite = SceneControl.Instance.keySprite[SceneControl.Instance.keyName.Count];
            Destroy(gameObject);
        }
   }
}
