using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Check if references are assigned
    }

    // Update is called once per frame
    void Update()
    {
        // No need for any update logic here
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure that player and respawnPoint are not null
        if (other.gameObject.CompareTag("Player"))  // Fixed typo here
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
