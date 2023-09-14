using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Vector2 rayDirection = Vector2.down;
    private float rayDistance = 5f;
    private Rigidbody2D rb2D;
    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Debug.Log("Impacto");
        }
    }
}



