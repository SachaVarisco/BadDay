using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    [SerializeField] private float suavizado;
    [SerializeField] private Vector2 velocity;
    private GameObject player;
    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX,min.x,max.x), Mathf.Clamp(posY,min.y,max.y), transform.position.z);
    }
}
