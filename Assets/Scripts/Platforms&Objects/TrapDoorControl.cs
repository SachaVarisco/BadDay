using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoorControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {   
        if (Input.GetAxis("Jump")!= 0)
        {
            SceneManager.LoadScene("Basement");
        }
    }

}
