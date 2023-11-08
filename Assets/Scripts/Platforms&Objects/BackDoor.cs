using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackDoor : MonoBehaviour
{
   [SerializeField] private GameObject feedback;
    private GameObject Lock;
    private bool canPass = false;
    private GameObject canvas;
    private void Start() {
        Lock = GameObject.FindGameObjectWithTag("Lock");
        canvas = GameObject.FindGameObjectWithTag("Canva");
    }
    private void Update() {
        if (canPass  && SceneTransition.Instance.canPass)
        {
            if (Input.GetButtonDown("Jump" )){
               canvas.GetComponent<SceneTransition>().ChangeScene("Back");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {          
        if (other.CompareTag("Player")){
            if (Lock == null || !Lock.activeSelf)
            {
                canPass = true;
                SceneTransition.Instance.canPass = true;
                feedback.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {          
        if (other.CompareTag("Player")){
             if (Lock == null || !Lock.activeSelf)
            {
                canPass = false;
                SceneTransition.Instance.canPass = false;
                feedback.SetActive(false);
            } 
        } 
    }
}
