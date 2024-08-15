using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoxLight : MonoBehaviour
{       
    public Transform[] PlayerGrabTransforms; // Array of player grab transforms
    public GameObject lightToActivate;  // Reference to the light to activate
    public float activationRange = 5f; // Range within which the light activates

    private void Update()
    {
        bool isAnyInRange = false; // Flag to track if any player grab transform is in range

        // Iterate through each player grab transform
        for (int i = 0; i < PlayerGrabTransforms.Length; i++)
        {
            if (PlayerGrabTransforms[i] == null)
            {
                Debug.LogWarning("PlayerGrabTransforms element at index " + i + " is not assigned.");
                continue;
            }

            // Calculate the distance between this GameObject and the current player grab transform
            float distance = Vector3.Distance(transform.position, PlayerGrabTransforms[i].position);

            // Check if the distance is within the activation range
            if (distance <= activationRange)
            {
                isAnyInRange = true; // Set flag if any transform is in range
                break; // Exit loop early if we found one in range
            }
        }

        // Activate or deactivate the light based on the flag
        lightToActivate.SetActive(isAnyInRange);
    }
}

