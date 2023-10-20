using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool talking = false;

    [Header("Speed")]
    public float speed;

    [Header("Jump")]
    [SerializeField] private float force;
    [SerializeField] private LayerMask isGround;
    [SerializeField] private Transform groundControl;
    [SerializeField] private Vector3 boxDimension;
    [SerializeField] private bool inGround;
    private bool jump = false;
    private bool isDeath = false;
    private bool lookLeft = false;
    private float horizontalMove;
    private Rigidbody2D rb2D;
    private Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        horizontalMove = speed * Input.GetAxisRaw("Horizontal")  * Time.deltaTime;
        animator.SetFloat("MoveY", rb2D.velocity.y);
        animator.SetBool("InGround", inGround);
        inGround = Physics2D.OverlapBox(groundControl.position, boxDimension, 0f, isGround);
        if (!isDeath)
        {
            Move(jump);
        }
        jump = false;

        if (horizontalMove > 0 && lookLeft) 
        {
            Rotate(); 
        }
        if (horizontalMove < 0 && !lookLeft)
        {
            Rotate(); 
        }
    }
    private void Move(bool jump){
        if (Input.GetAxis("Horizontal")!= 0 && !talking)
        {  
            transform.position += new Vector3(horizontalMove, 0);
            animator.SetFloat("MoveX",Mathf.Abs(horizontalMove));
        }
        if(inGround && jump && !talking)
        {
            inGround = false;
            rb2D.AddForce(new Vector2(0, force));
        }
    }
    public void Spring(){
        rb2D.AddForce(new Vector2(0, 600));
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundControl.position, boxDimension);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Dish")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Dish")
        {
            transform.parent = null;
        }
    }
    private void Rotate(){
        lookLeft = !lookLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
