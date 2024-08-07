using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public float bounceheight = 10f;    // The force applied upwards
    public float bouncedistance = 10f;    // The force applied upwards

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("WholeNote"))
        {
        Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        // playerRigidbody.AddForce(Vector2.up * bounceheight, ForceMode2D.Impulse);
        // playerRigidbody.AddForce(Vector2.right * bouncedistance, ForceMode2D.Impulse);

        Vector2 direction = Vector2.up + (Vector2.right*2);

        playerRigidbody.AddForce(direction * 50, ForceMode2D.Impulse);

        }}}