using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxLight : MonoBehaviour
{       
    public GameObject lightToActivate;  // Reference to the light to activate
     public GameObject[] Players; // Array of Player GameObjects
    private GrabController[] playerDetectionScripts; // Array of GrabController scripts
    public float detectionRadius = 10f;

    private void Start()
    {
        if (Players != null && Players.Length > 0)
        {
            // Initialize the playerDetectionScripts array
            playerDetectionScripts = new GrabController[Players.Length];

            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i] != null)
                {
                    playerDetectionScripts[i] = Players[i].GetComponent<GrabController>();

                    if (playerDetectionScripts[i] == null)
                    {
                        Debug.LogError($"GrabController script not found on Player GameObject at index {i}.");
                    }
                }
                else
                {
                    Debug.LogError($"Player GameObject at index {i} is not assigned.");
                }
            }
        }
        else
        {
            Debug.LogError("Players array is not assigned or is empty.");
        }
    }

    private void Update()
    {
        if (playerDetectionScripts == null || playerDetectionScripts.Length == 0)
        {
            Debug.LogWarning("GrabController scripts are not assigned.");
            return;
        }

        // Check if any player has inRange set to true
        bool anyInRange = false;
        foreach (GrabController script in playerDetectionScripts)
        {
            if (script != null && script.inRange)
            {
                anyInRange = true;
                break; // No need to check further if we already found one player in range
            }
        }

        GameObject closestPlayer = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject player in Players)
        {
            if (player != null)
            {
                float distanceSqr = (transform.position - player.transform.position).sqrMagnitude;
                if (distanceSqr < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceSqr;
                    closestPlayer = player;
                }
            }
        }
        bool PlayerClose = false;
        if (closestPlayer != null)
        {
            float distance = Mathf.Sqrt(closestDistanceSqr);
            if (distance <= detectionRadius)
            {
               // Debug.Log("" + distance);

                 PlayerClose = true;
            }
        }
        bool LightON = false;
        if (anyInRange){ //if(anyInRange && PlayerClose){
            LightON = true;
        }
        if (lightToActivate != null)
        {
            lightToActivate.SetActive(LightON);
        }
        else
        {
            Debug.LogWarning("Light GameObject is not assigned.");
        }
    
}}