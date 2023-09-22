using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEye : MonoBehaviour
{
    
    [SerializeField] private GameObject father;
   
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            Rigidbody2D rb2D = father.GetComponent<Rigidbody2D>();
            rb2D.gravityScale = 3f;
        }
    }
}
