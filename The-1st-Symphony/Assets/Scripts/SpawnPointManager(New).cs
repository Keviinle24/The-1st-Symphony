using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManagerLvl3 : MonoBehaviour
{
    public Transform newSpawn;
    public GameObject[] players;
    public GameObject CheckpointTrigger;
        private HashSet<GameObject> enteredPlayers = new HashSet<GameObject>();




void DeleteBox()
{
    CheckpointTrigger.SetActive(false);

}

void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer(other.gameObject))
        {
            other.GetComponent<Walk_mechanic>().SetSpawnPoint(newSpawn);

            enteredPlayers.Add(other.gameObject);

            // Check if all players have entered
            if (AllPlayersEntered())
            {
                DeleteBox();
            }
        }
    }

    private bool IsPlayer(GameObject obj)
    {
        foreach (GameObject player in players)
        {
            if (obj == player)
            {
                return true;
            }
        }
        return false;
    }

    private bool AllPlayersEntered()
    {
        foreach (GameObject player in players)
        {
            if (!enteredPlayers.Contains(player))
            {
                return false;
            }
        }
        return true;
    }
}
