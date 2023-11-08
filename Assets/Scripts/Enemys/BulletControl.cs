using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
     [SerializeField] private float speed;
    private float setTime = 1;
    private float currentTime;
    private Transform player;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = setTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();

        Vector3 direction = player.position - transform.position;
        rb2D.velocity = new Vector2(direction.x,direction.y).normalized * speed;
    }
    private void Update() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
          other.gameObject.GetComponent<PLayerLifeControl>().TakeDamage(other.GetContact(0).normal);
          Destroy(gameObject);
        }
    }
}
