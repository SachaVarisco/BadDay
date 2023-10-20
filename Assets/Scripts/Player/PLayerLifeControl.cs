using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayerLifeControl : MonoBehaviour
{
    private string actualScene;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
    }

    public void TakeDamage(){
        if (SceneControl.Instance.playerLife > 0)
        {
            SceneControl.Instance.playerLife -= 1;
            SceneControl.Instance.ChangeUI();
        }else if (SceneControl.Instance.playerLife <= 0)
        {
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
}
