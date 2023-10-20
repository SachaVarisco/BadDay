using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            animator.SetBool("Spring",true);
            SceneControl.Instance.PlaySound(audio);
            other.GetComponent<PlayerController>().Spring();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            animator.SetBool("Spring",false);
        }
    }
   
}
