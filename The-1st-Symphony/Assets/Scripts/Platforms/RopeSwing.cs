using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    public Transform ropeEnd; 
    public float swingForce = 10f; 
    public float maxSwingAngle = 30f; 

    private Rigidbody2D playerRb;
    private bool isSwinging = false;

    private void Update()
    {
        if (isSwinging)
        {
            Vector2 directionToRope = (Vector2)ropeEnd.position - (Vector2)transform.position;

            if (playerRb != null)
            {
                playerRb.AddForce(directionToRope.normalized * swingForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
            isSwinging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            isSwinging = false;
            playerRb = null;
        }
    }
}
