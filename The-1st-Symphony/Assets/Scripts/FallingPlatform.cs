using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = .4f;
    //private float destroyDelay = 4f;

    [SerializeField] private Rigidbody2D rb;

    private Vector2 initialPosition;
    private RigidbodyType2D initialBodyType;
    private float initialGravityScale;

    private void Start()
    {
        initialPosition = transform.position;
        initialBodyType = rb.bodyType;
        initialGravityScale = rb.gravityScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") || other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote")) {
        
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 5;
       // Destroy(gameObject, destroyDelay);
    }

    public void ResetPlatform()
    {
        transform.position = initialPosition;
        rb.bodyType = initialBodyType;
        rb.gravityScale = initialGravityScale;
        rb.velocity = Vector2.zero; // Optional: Reset velocity if needed
        rb.angularVelocity = 0;    // Optional: Reset angular velocity if needed
    }

         private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger"))
        {
            ResetPlatform();
        }
    }
}
