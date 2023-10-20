using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneControl.Instance.stair == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            gameObject.transform.position = new Vector3(8f, -1f, 0f);
        }
    }
}
