using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    public bool canPass;
    private Animator animator;
    [SerializeField] private AnimationClip finalAnimation;

    private void Awake() {
        if (SceneTransition.Instance == null)
        {
            SceneTransition.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
    }
    public void ChangeScene(string scene){
        StartCoroutine(Transition(scene));
    }
    IEnumerator Transition(string scene){
        canPass = false;
        animator.SetBool("Exit",true);
        yield return new WaitForSeconds(finalAnimation.length);
        switch (scene)
        {
            case "Stair" :
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Trap": 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                break;
            case "Back":
                SceneManager.LoadScene("Garden");
                break;
            case "Final":
                SceneManager.LoadScene("Finish");
                break;
            case "Garden":
            SceneManager.LoadScene("FirstFloor");
                break;
        }
        animator.SetBool("Exit", false);
        canPass = true;
    }

}
