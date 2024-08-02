using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatButton : MonoBehaviour
{
    public GameObject button;
    private SpriteRenderer spriteRenderer;
    public MovedPlat platformScript; 


    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
           button.SetActive(false);
            if (platformScript != null)
            {
                platformScript.ActivatePlatform();
            }
        }
    }
        }