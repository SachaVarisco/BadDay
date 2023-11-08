using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private GameObject feedback;
    private bool canPass;
    private bool allBone;
    private GameObject canvas;
    private void Start() {
        canvas = GameObject.FindGameObjectWithTag("Canva");
    }
    private void Update() {
        if (canPass  && SceneTransition.Instance.canPass)
        {
            if (Input.GetButtonDown("Jump"))
            {
                canvas.GetComponent<SceneTransition>().ChangeScene("Final");
            }
        }
        if (SceneControl.Instance.boneName.Count >= 8)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            allBone = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {          
        if (other.CompareTag("Player") && allBone ){
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
