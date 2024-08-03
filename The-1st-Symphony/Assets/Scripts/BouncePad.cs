using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float bounce;
    [SerializeField] private Vector2 directions;
    public float Bounce => bounce;
    public Vector2 Directions => directions;

    private void OnCollisionEnter2D(Collision2D collision) {
        // if (collision.gameObject.CompareTag("player")) {
        //     collision.gameObject.GetComponent<Rigidbody2D>().AddForce(directions * bounce, ForceMode2D.Impulse);
        // }
        EventManager.HitBouncePad(collision.gameObject.tag, this);
    }
}
