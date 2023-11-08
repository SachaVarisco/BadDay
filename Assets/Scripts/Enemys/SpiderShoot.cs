using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShoot : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletController;
    private float setTime = 2;
    private float currentTime;
    private Animator animator;
    private bool canShoot = false;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        currentTime = setTime;
    }
    private void Update() {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
           canShoot = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (canShoot)
            {
               animator.SetBool("Shoot", true);
            currentTime = setTime; 
            }
        }
    }
    private void Shoot(){
        Instantiate(bulletPrefab, bulletController.position, Quaternion.identity);
        SceneControl.Instance.PlaySound(audio);
        animator.SetBool("Shoot", false);
    }
}
