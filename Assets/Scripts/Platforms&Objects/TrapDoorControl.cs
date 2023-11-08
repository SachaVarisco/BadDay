using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoorControl : MonoBehaviour
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
        if (canPass && SceneTransition.Instance.canPass)
        {
            if (Input.GetButtonDown("Jump")){
                if (SceneManager.GetActiveScene().name == "Garden")
                {
                    //SceneManager.LoadScene("FirstFloor");
                    canvas.GetComponent<SceneTransition>().ChangeScene("Garden");
                }else{
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    canvas.GetComponent<SceneTransition>().ChangeScene("Trap");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {          
        if (other.CompareTag("Player")){
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
