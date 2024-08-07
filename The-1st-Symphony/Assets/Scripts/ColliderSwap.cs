using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSwap : MonoBehaviour
{
     public Collider2D colliderA;  
    public Collider2D colliderB;  
    private void Start()
    {
        colliderA.enabled = true;
        colliderB.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PassThroughPlat"))
        {
            colliderA.enabled = false;
            colliderB.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PassThroughPlat"))
        {
            colliderB.enabled = false;
            colliderA.enabled = true;
        }
    }
}