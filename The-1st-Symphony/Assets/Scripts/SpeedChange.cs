using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChange : MonoBehaviour
{
    public float playerSpeed = 15f;
    public float playerJump = 30f;
    public float playerClimb = 15f;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        var platformMovement = other.GetComponent<Walk_mechanic>();
    if (platformMovement != null) 
    { 
        if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
    {
        platformMovement.ChangeSpeed( playerSpeed, playerJump, playerClimb);

    }
    }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        var platformMovement = other.GetComponent<Walk_mechanic>();
    if (platformMovement != null) 
    { 
        if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
    {
        platformMovement.ResetSpeed();

    }
    }
    }

    //  private void OnCollisionEnter2D(Collision2D other)
    // {
    //     var platformMovement = other.collider.GetComponent<Walk_mechanic>();
    // if (platformMovement != null) 
    // { 
    //     if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
    // {
    //     platformMovement.ChangeSpeed( playerSpeed, playerJump, playerClimb);

    // }
    // }
    // }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     var platformMovement = other.collider.GetComponent<Walk_mechanic>();
    // if (platformMovement != null) 
    // { 
    //     if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
    // {
    //     platformMovement.ResetSpeed();

    // }
    // }
    // }

}
