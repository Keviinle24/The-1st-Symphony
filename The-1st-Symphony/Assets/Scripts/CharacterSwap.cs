using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
     public GameObject[] characters; // Array of character GameObjects
    private int activeCharacterIndex = 0; // Index of the currently active character

    void Start()
    {
        // Ensure only the first character is initially active
        SetActiveCharacter(activeCharacterIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter(1);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4)) //left bumper
        {
            SwitchCharacter(-1); //switch to previous character
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5)) //right bumper
        {
            SwitchCharacter(1); //switch to next character
        }
    }

    void SwitchCharacter(int direction = 1)
    {
        // Deactivate the current active character
        characters[activeCharacterIndex].SetActive(false);

        // Move to the next character (looping back to the first if needed)
        activeCharacterIndex = (activeCharacterIndex + direction + characters.Length) % characters.Length;

        // Activate the new active character
        SetActiveCharacter(activeCharacterIndex);
    }

    void SetActiveCharacter(int index)
    {
        characters[index].SetActive(true);
    }
}