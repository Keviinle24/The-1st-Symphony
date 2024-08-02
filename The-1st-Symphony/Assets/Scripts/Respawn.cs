using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour

{
    public Transform spawnPoint; 
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}

