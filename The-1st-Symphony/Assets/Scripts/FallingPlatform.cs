//Add Rigidbody to the falling object platform
//Switch body type to kinematic so that I can control the physics of the object

using System.Collections; // Allows the use of IEnumerator for coroutines.
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = .4f; // Time delay before the platform starts to fall.
    private float destroyDelay = 4f; // Time delay before the platform is destroyed after it starts falling.

    [SerializeField] private Rigidbody2D rb; // A reference to the Rigidbody2D component attached to the platform. [SerializeField] allows it to be set in the Unity Editor.

    private void OnCollisionEnter2D(Collision2D collision) // This function is called when another object collides with the platform.
    {
        if (collision.gameObject.CompareTag("player")) // Checks if the object that collided has the tag "player".
        {
            StartCoroutine(Fall()); // Starts the coroutine Fall() to handle the falling action.
        }
    }

    private IEnumerator Fall() // Defines a coroutine called Fall() that can pause execution.
    {
        yield return new WaitForSeconds(fallDelay); // Pauses the coroutine for fallDelay seconds.
        rb.bodyType = RigidbodyType2D.Dynamic; // Changes the Rigidbody2D to Dynamic, making it fall due to gravity.
        rb.gravityScale = 5; // Increases the gravity scale for faster falling.
        Destroy(gameObject, destroyDelay); // Destroys the game object after destroyDelay seconds.
    }
}
