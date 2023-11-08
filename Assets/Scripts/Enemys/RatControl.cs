using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatControl : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    private int randNum;
    [SerializeField]private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private bool lookLeft = true;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private float velocityX;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        randNum = Random.Range(0,wayPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[randNum].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[randNum].position) < minDistance)
        {
            randNum = Random.Range(0,wayPoints.Length);
        } 
    }
    private void FixedUpdate() 
    {
        
        Speed();
        if (velocityX > 0 && lookLeft) 
        {
            //spriteRenderer.flipX = false; 
            Rotate(); 
        }
        if (velocityX < 0 && !lookLeft)
        {
            Rotate(); 
        }
    }
    private float Speed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        velocityX = (currentPosition.x - previousPosition.x) / deltaTime;

        previousPosition = currentPosition;

        return velocityX;
    }
    private void Rotate(){
        lookLeft = !lookLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnCollisionEnter2D(Collision2D other)
   {
     if (other.gameObject.tag == "Player"){
          other.gameObject.GetComponent<PLayerLifeControl>().TakeDamage(other.GetContact(0).normal);
        }
   }
}
