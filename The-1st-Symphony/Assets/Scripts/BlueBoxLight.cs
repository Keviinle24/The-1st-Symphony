using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxLight : MonoBehaviour
{       
    public GameObject lightToActivate;  // Reference to the light to activate
     public GameObject[] Players; // Array of Player GameObjects
    private GrabController[] playerDetectionScripts; // Array of GrabController scripts

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

        // Activate or deactivate the light based on the flag
        if (lightToActivate != null)
        {
            lightToActivate.SetActive(anyInRange);
        }
        else
        {
            Debug.LogWarning("Light GameObject is not assigned.");
        }
    }
}