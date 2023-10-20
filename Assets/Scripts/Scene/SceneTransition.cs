using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
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
    }
    private void Start(){
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(this.gameObject);
    } 
    public void ChangeScene(string scene){
        StartCoroutine(Transition(scene));
    }
    IEnumerator Transition(string scene){
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(finalAnimation.length);
        SceneManager.LoadScene(scene);
    }

}
