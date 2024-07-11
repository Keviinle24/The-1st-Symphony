using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox; 
    public TMP_Text dialogueText; 
    private bool dialogueActive = false; 
    public GameObject player;
    public float delay = 1f;

    void Start()
    {
        dialogueBox.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogueActive)
        {
            StartDialogue("Hello! This is the beginning of the dialogue. Lets Get out of here.");
            Rigidbody2D pRb = player.GetComponent<Rigidbody2D>();
           
            if (pRb != null)
        {
            StartCoroutine(ResetVelocityAfterDelay(delay));
            player.GetComponent<Walk_mechanic>().SetMovementEnabled(false);
        }
            else
        {
            Debug.LogWarning("Rigidbody2D component not found on player GameObject.");
        }
           
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dialogueActive)
        {
            EndDialogue();
        player.GetComponent<Walk_mechanic>().SetMovementEnabled(true);

        }
    }

    void StartDialogue(string dialogue)
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
    }
    
    public IEnumerator ResetVelocityAfterDelay(float delay)
    {
        Rigidbody2D playRb = player.GetComponent<Rigidbody2D>();

        yield return new WaitForSeconds(delay);
        playRb.velocity = Vector2.zero;
        Debug.Log("Velocity is " + playRb.velocity);

    }
}