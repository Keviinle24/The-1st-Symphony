using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUmpAdjusttrigger : MonoBehaviour
{
        public float increasedGravityScale = 4f;
        public float originalGravity = 2.25f;
        private bool isInEnterTrigger = false;
        private bool isInExitTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isInEnterTrigger)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = increasedGravityScale;
            isInEnterTrigger = true;
        }
    }
}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isInEnterTrigger && !isInExitTrigger)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = originalGravity;
            isInEnterTrigger = false;
        }
    }
}

    void OnTriggerExit2DExit(Collider2D other)
    {
        if (other.CompareTag("Player") && isInExitTrigger)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = originalGravity;
                isInExitTrigger = false;
            }
        }
    }
}

