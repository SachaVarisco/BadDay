using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoorControl : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private void OnTriggerStay2D(Collider2D other)
    {   
        if (Input.GetButtonDown("Jump"))
        {
            //canvas.GetComponent<SceneTransition>().ChangeScene("Basement");
            SceneManager.LoadScene("Basement");
        }
    }

}
