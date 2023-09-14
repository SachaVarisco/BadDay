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
        float velocityX = rb2D.velocity.x;
        /*if(velocityX > 0 && lookLeft){
            Rotate();
        }
        if (velocityX < 0 && !lookLeft)
        {
            Rotate();
        }*/
        if (velocityX > 0) 
        {
            spriteRenderer.flipX = false; 
        }
        else if (velocityX < 0) 
        {
            spriteRenderer.flipX = true;
        }
    }
    private void Rotate(){
        lookLeft = !lookLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
