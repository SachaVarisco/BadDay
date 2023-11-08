using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairControl : MonoBehaviour
{
    
    [SerializeField] private GameObject feedback;
    private bool canPass = false;
    private GameObject Lock;
    private GameObject canvas;
    private void Start() {
        Lock = GameObject.FindGameObjectWithTag("Lock");
        canvas = GameObject.FindGameObjectWithTag("Canva");
    }
    private void Update() {
        if (canPass  && SceneTransition.Instance.canPass)
        {
            if (Input.GetButtonDown("Jump")){
                SceneControl.Instance.table = true;
                canvas.GetComponent<SceneTransition>().ChangeScene("Stair"); 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {          
        if (gameObject.name == "AtticDoor")
        {
            if ((!Lock.activeSelf || Lock == null) && other.CompareTag("Player"))
            {
                canPass = true;
                SceneTransition.Instance.canPass = true;
                feedback.SetActive(true);
            }
        } else if (other.CompareTag("Player")){
            canPass = true;
            SceneTransition.Instance.canPass = true;
            feedback.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {          
        if (other.CompareTag("Player")){
            canPass = false;
            SceneTransition.Instance.canPass = false;
            feedback.SetActive(false);   
        } 
    }
}
