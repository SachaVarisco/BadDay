using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayerLifeControl : MonoBehaviour
{
    private string actualScene;
    private Animator animator;
    private Rigidbody2D rb2D;
    [SerializeField] private Vector2 damageJump;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(Vector2 pointDamage){
        if (SceneControl.Instance.playerLife > 0)
        {
            rb2D.velocity = new Vector2(-damageJump.x * pointDamage.x, damageJump.y);
            animator.SetTrigger("Damage");
            SceneControl.Instance.playerLife -= 1;
            SceneControl.Instance.ChangeUI();
            rb2D.AddForce(new Vector2(0, 100));
        }else if (SceneControl.Instance.playerLife <= 0)
        {
            
            SceneControl.Instance.playerLife = 2;
            SceneManager.LoadScene(actualScene);
        }

    }

    public void RestLife(){
        if (SceneControl.Instance.playerLife < 2)
        {
            SceneControl.Instance.playerLife += 1;
            SceneControl.Instance.ChangeUI();
        }
    }
    private IEnumerator LoseControl(){
        gameObject.GetComponent<PlayerController>().isDeath = true;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<PlayerController>().isDeath = false;
    }
}
