using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject button;
    public GameObject[] doors;
    private SpriteRenderer spriteRenderer;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
           button.SetActive(false);
           for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(false);

        }

        }
    }
        }