using System.Collections;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] lines;
    private bool playerInRange;
    private bool dialogueStarted;
    private int lineIndex;
    private float typingTime = 0.05f;
    


    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Jump"))
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
}
