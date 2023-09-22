using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public static SceneControl Instance;
    [SerializeField] private float boneCounter;
    public bool redKey = false;
    
    private void Awake() {
        if (SceneControl.Instance == null)
        {
            SceneControl.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddBones(){
        boneCounter += 1;
    }

    public void HaveKey(){
        redKey = true;
    }
}
