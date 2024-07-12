using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Button : MonoBehaviour
{
    public GameObject button;
    public GameObject bridge;
    public GameObject exitPortal;
    private SpriteRenderer spriteRenderer;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            Color newColor = spriteRenderer.color;
            newColor.a = 0f;  
            spriteRenderer.color = newColor;

            bridge.SetActive(true);
            if (exitPortal != null)
            {
                exitPortal.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            if (spriteRenderer.color.a == 0f)
            {
            Color newColor = spriteRenderer.color;
            newColor.a = 1f;  
            spriteRenderer.color = newColor;
            }
            bridge.SetActive(false);
            if (exitPortal != null)
            {
                exitPortal.SetActive(false);
            }
        }
    }
}

