using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    private float horizontalMove;

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        

        inGround = Physics2D.OverlapBox(groundControl.position, boxDimension, 0f, isGround);
        if (!isDeath)
        {
            Move(jump);
        }
        jump = false;
    }

    private void Move(bool jump){
        if (Input.GetAxis("Horizontal")!= 0)
        {
            transform.position += new Vector3(horizontalMove, 0);
        }

        if(inGround && jump)
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

}
