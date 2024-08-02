using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityAdjust2 : MonoBehaviour
{
        public float increasedGravityScale = 4f;
        public float originalGravity = 2.25f;
        private bool isInTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote")) && !isInTrigger)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = increasedGravityScale;
            isInTrigger = true;
        }
    }
}
    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote")) && isInTrigger)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = originalGravity;
            isInTrigger = false;
        }
    }
}
}

