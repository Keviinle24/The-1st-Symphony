using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAppearUI : MonoBehaviour
{
  

    public GameObject dialogueBox; 
    private bool dialogueActive = false; 

    void Start()
    {
        dialogueBox.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote")) && !dialogueActive)
        {
            dialogueBox.SetActive(true);
            dialogueActive = true;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote")) && dialogueActive)
        {
        dialogueBox.SetActive(false);
        dialogueActive = false;
        Destroy(gameObject, 5f);
        }
    }

}