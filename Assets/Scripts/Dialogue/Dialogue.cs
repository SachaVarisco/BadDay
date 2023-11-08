using System.Collections;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public bool autoDialogue = false;
    private GameObject panel;
    private TextMeshProUGUI dialogueText;
    private GameObject dialogueMark;
    private GameObject player;
    [SerializeField, TextArea(4,6)] private string[] lines;
    [SerializeField] private AudioClip audio;
    private bool playerInRange;
    private bool dialogueStarted;
    private int lineIndex;
    private float typingTime = 0.05f;
    private GameObject cloud;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueMark = gameObject.transform.GetChild(0).gameObject;
        SearchUI();
    }
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (!dialogueStarted)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == lines[lineIndex])
                {
                    NextDialogueLine();
                }else
                {
                    StopAllCoroutines(); 
                    dialogueText.text = lines[lineIndex];
                }
            }
        }   
        if (autoDialogue)
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }else if (Input.GetButtonDown("Jump")){
                if (dialogueText.text == lines[lineIndex])
                {
                    NextDialogueLine();
                }else
                {
                    StopAllCoroutines(); 
                    dialogueText.text = lines[lineIndex];
                    
                }
            }
        }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            dialogueMark.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            playerInRange = false;
            dialogueMark.SetActive(false);
        }
        
    }
    private void StartDialogue(){
        SceneControl.Instance.PlaySound(audio);
        dialogueStarted = true;
        panel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        player.GetComponent<PlayerController>().talking = true;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine(){
        lineIndex++;
        if (lineIndex < lines.Length)
        {
            StartCoroutine(ShowLine());
        }else
        {
            dialogueStarted = false;
            autoDialogue = false;
            panel.SetActive(false);
            dialogueMark.SetActive(true);
            player.GetComponent<PlayerController>().talking = false;
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach (char ch in lines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    public void SearchUI(){
        cloud = GameObject.FindGameObjectWithTag("Canva");
        panel = cloud.transform.GetChild(2).gameObject;
        dialogueText = panel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

    }

}
