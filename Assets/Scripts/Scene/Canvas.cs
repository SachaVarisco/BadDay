using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Canvas : MonoBehaviour
{
    private void Start() {
        if (SceneManager.GetActiveScene().name == "Finish")
        {
            GameObject ScneneTrans = GameObject.FindGameObjectWithTag("Canva");
            GameObject SceneCont= GameObject.FindGameObjectWithTag("SceneControl");
            Destroy(SceneCont);
            Destroy(ScneneTrans);
        }
    }
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credits");
    }
     public void Reset()
    {
        SceneManager.LoadScene("Menu");
    }
}
