using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public static SceneControl Instance;
    public bool redKey = false;
    public bool stair = false; 
    public List<string> boneName = new List<string>(); 
    public Image playerLifeUI;
    public int playerLife;
    [SerializeField] private Sprite[] skullSprite;
    public Image Keys;
    private AudioSource audioSource;
    private void Awake() {
        playerLifeUI.sprite = skullSprite[playerLife];
        audioSource = GetComponent<AudioSource>();
        if (SceneControl.Instance == null)
        {
            SceneControl.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        //playerLifeUI.sprite = skullSprite[playerLife];
        SceneManager.sceneLoaded += ChargedScene;
    }
    private void OnDisable()
    {
        playerLifeUI.sprite = skullSprite[playerLife];
        SceneManager.sceneLoaded -= ChargedScene;
    }

    private void ChargedScene(Scene scene, LoadSceneMode mode)
    {
        foreach (string word in boneName)
        {
            GameObject[] entities = GameObject.FindGameObjectsWithTag("Bone");
            foreach (GameObject entitie in entities)
            { 
                if (entitie.name == word)
                {
                    entitie.SetActive(false);
                }
                
            }
        }
        if (scene.name == "Basement" && stair == true)
        {
            Vector3 newPosition = new Vector3(47f, -4f, 0f);

            GameObject[] entities = GameObject.FindGameObjectsWithTag("Bone");
            

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = newPosition;
        }
    }

    public void PlaySound(AudioClip sound){
        audioSource.PlayOneShot(sound);
    }

    public void PushName(string name)
    {
        boneName.Add(name);
        Debug.Log(boneName.Count);
    }

    public void ChangeUI(){
        playerLifeUI.sprite = skullSprite[playerLife];
    }
}
