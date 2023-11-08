using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float leftLimit = 0.3f;
    private float rightLimit = 0.3f;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.angularVelocity = 500;
    }

    // Update is called once per frame
    void Update()
    {
        SwingMove();
    }
    private void SwingMove(){
        if (transform.rotation.z < rightLimit && rb2D.angularVelocity > 0 && rb2D.angularVelocity < speed)
        {
            rb2D.angularVelocity = speed;
        }else if (transform.rotation.z > leftLimit && rb2D.angularVelocity < 0 && rb2D.angularVelocity > -speed)
        {
            rb2D.angularVelocity = -speed;
        }
    }
}
