using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public Transform newSpawn;
    public GameObject[] players;
    public GameObject CheckpointTrigger;


    private void OnTriggerEnter2D(Collider2D other)
    {
if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))        {
            //changes the player's spawn point
            for (int i = 0; i < players.Length; i++) {
            players[i].GetComponent<Walk_mechanic>().SetSpawnPoint(newSpawn);
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))        {
        {
            CheckpointTrigger.SetActive(false);
        }
    }
}
}
