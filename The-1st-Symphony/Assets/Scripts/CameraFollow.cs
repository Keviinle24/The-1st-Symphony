// Code originally used by David Wood
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float offsetx;
    public float offsety;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x - offsetx, playerPosition.y - offsety, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offsetx, playerPosition.y - offsety, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }   
}