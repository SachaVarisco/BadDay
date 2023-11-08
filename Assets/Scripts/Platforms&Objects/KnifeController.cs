using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D other)
     {
          if (other.gameObject.tag == "Player"){
               other.gameObject.GetComponent<PLayerLifeControl>().TakeDamage(other.GetContact(0).normal);
          }
     }
}