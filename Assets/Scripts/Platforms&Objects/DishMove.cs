using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishMove : MonoBehaviour
{
    public GameObject dish;
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    private Vector3 moveTo;
    void Start()
    {
        moveTo.y = dish.transform.position.y;
        moveTo.x = endPoint.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        dish.transform.position = Vector3.MoveTowards(dish.transform.position, moveTo, speed*Time.deltaTime);
        if (dish.transform.position.x == endPoint.position.x)
        {
            moveTo = startPoint.position;
        }
        if (dish.transform.position.x == startPoint.position.x)
        {
            moveTo = endPoint.position;
        }
        
    }
}
