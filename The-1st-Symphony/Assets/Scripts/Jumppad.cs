using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    [SerializeField] private float bounce;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
