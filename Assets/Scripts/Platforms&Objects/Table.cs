using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    void Start()
    {
        if (SceneControl.Instance.table == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            gameObject.transform.position = new Vector3(8f, -2f, 0f);
        }
    }
}
