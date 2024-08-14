using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UnlockDialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _DialogueBoxFirst;
    public GameObject dialogueBox; 
    public TMP_Text dialogueText; 
    private bool dialogueActive = false; 
    public GameObject[] players;
    public float delay = 1f;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is one of the note types
        if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
        {
            if (!dialogueActive)
            {
                StartDialogue();
                
                foreach (GameObject player in players)
                {
                    Rigidbody2D pRb = player.GetComponent<Rigidbody2D>();
                    if (pRb != null)
                    {
                        StartCoroutine(ResetVelocityAfterDelay(pRb, delay));
                        player.GetComponent<Walk_mechanic>().SetMovementEnabled(false);
                        player.GetComponent<CharacterSwap>().SetSwapEnabled(false);

                    }
                    else
                    {
                        Debug.LogWarning("Rigidbody2D component not found on player GameObject.");
                    }
                }
                
                EventSystem.current.SetSelectedGameObject(_DialogueBoxFirst);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger is one of the note types
        if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
        {
            if (dialogueActive)
            {
                EndDialogue();
                
                foreach (GameObject player in players)
                {
                    player.GetComponent<Walk_mechanic>().SetMovementEnabled(true);
                }

                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    void StartDialogue()
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
    }
    
    public IEnumerator ResetVelocityAfterDelay(Rigidbody2D playerRb, float delay)
    {
        yield return new WaitForSeconds(delay);
        playerRb.velocity = Vector2.zero;
        Debug.Log("Velocity is " + playerRb.velocity);
    }
}
