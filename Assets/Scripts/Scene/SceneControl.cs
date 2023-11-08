using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public static SceneControl Instance;
    public string previousScene;
    public bool anvil = false;
    public bool table = false;
    public List<string> boneName = new List<string>();
    public List<string> keyName = new List<string>();
    public List<string> lockName = new List<string>();
    public TextMeshProUGUI boneCounter;
    public Image playerLifeUI;
    public int playerLife;
    public Sprite[] keySprite;
    public Image keys;
    [SerializeField] private Sprite[] skullSprite;
    private GameObject finalDoor;
    private AudioSource audioSource;
    private void Awake() {
        if (SceneControl.Instance == null)
        {
            SceneControl.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }  else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        finalDoor = GameObject.Find("FinalDoor");
        SearchUI();
    }

    private void Update() {
        if (boneName.Count == 8)
        {
            boneCounter.text = (boneName.Count).ToString();
            GameObject seesaw = GameObject.Find("BreakSeesaw");
            seesaw.GetComponent<Seesaw>().allBone = true;
            boneName.Add("FinalBone");
        }else if (boneName.Count <= 8)
        {
            if(finalDoor != null){
                finalDoor.GetComponent<FinalDoor>().enabled = false;
            }
            boneCounter.text = (boneName.Count).ToString();
        }
        playerLifeUI.sprite = skullSprite[playerLife];
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ChargedScene;
    }
    private void OnDisable()
    {
        playerLifeUI.sprite = skullSprite[playerLife];
        SceneManager.sceneLoaded -= ChargedScene;
    }

    private void ChargedScene(Scene scene, LoadSceneMode mode)
    {
        /*if (scene.name == "Basement" && previousScene == null){
            if (SceneControl.Instance == null)
            {
                SceneControl.Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }  else
            {
                Destroy(gameObject);
            }
        }*/
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
        foreach (string word in keyName)
        {
            GameObject[] entities = GameObject.FindGameObjectsWithTag("Key");
            foreach (GameObject entitie in entities)
            { 
                if (entitie.name == word)
                {
                    entitie.SetActive(false);
                }
            }
        }
        foreach (string word in lockName)
        {
            GameObject[] entities = GameObject.FindGameObjectsWithTag("Lock");
            foreach (GameObject entitie in entities)
            { 
                switch (entitie.name)
                {
                case "Green":
                GameObject door = GameObject.Find("AtticDoor");
                door.GetComponent<StairControl>().enabled = true;
                break;
                case "Blue":
                  GameObject door1 = GameObject.Find("BackDoor");
                  door1.GetComponent<BackDoor>().enabled = true;// Acciones a realizar para el caso value2
                break;
                }
                if (entitie.name == word)
                {
                    entitie.SetActive(false);
                }
            }
        }
        if (scene.name == "Basement" && previousScene == "FirstFloor")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(47f, -4f, 0f);
        }else if(scene.name == "FirstFloor" && previousScene == "Bedroom-Bath"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(12.6f, -4.3f, 0f);
        }else if(scene.name == "FirstFloor" && previousScene == "Garden"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(92f, -4.3f, 0f);
        }else if(scene.name == "Bedroom-Bath" && previousScene == "Vertical"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(23f, 6f, 0f);
        }else if(scene.name == "Vertical" && previousScene == "Attic"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(1f, 24f, 0f);
        }
        previousScene = scene.name;

        if (scene.name == "Garden" && anvil == true)
        {
            GameObject seeSaw = GameObject.Find("SeeSaw");
            seeSaw.transform.GetChild(1).gameObject.SetActive(false);
            seeSaw.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void PlaySound(AudioClip sound){
        audioSource.PlayOneShot(sound);
    }

    public void PushName(string name)
    {
        boneName.Add(name);
    }

    public void ChangeUI(){
        playerLifeUI.sprite = skullSprite[playerLife];
    }

    private void SearchUI(){
        GameObject canva = GameObject.FindGameObjectWithTag("Canva");
        playerLifeUI = canva.transform.GetChild(0).gameObject.GetComponent<Image>();
        boneCounter = canva.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        keys = canva.transform.GetChild(3).gameObject.GetComponent<Image>();
    }
}
