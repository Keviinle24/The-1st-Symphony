using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSwap : MonoBehaviour
{
    public GameObject[] characters; 
    public Camera[] cameras; 

    private int activeCharacterIndex = 0; 
    

    void Start()
    {

        //deactivates all characters and cameras 
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
            cameras[i].gameObject.SetActive(false);
        }
        //only the first character is active at start
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
        //deactivate the current active character
        characters[activeCharacterIndex].GetComponent<Walk_mechanic>().SetMovementEnabled(false);
        cameras[activeCharacterIndex].gameObject.SetActive(false);


        //move to the next character (loops back to the first if needed)
        activeCharacterIndex = (activeCharacterIndex + direction + characters.Length) % characters.Length;

        //activate the new active character
        SetActiveCharacter(activeCharacterIndex);
        characters[activeCharacterIndex].GetComponent<Walk_mechanic>().SetMovementEnabled(true);

    }

    void SetActiveCharacter(int index)
    {
        characters[index].SetActive(true);
        cameras[index].gameObject.SetActive(true);
    }

    public void NewCamera(GameObject newCamera)
    {
        Array.Resize(ref cameras, cameras.Length + 1);
        Camera cameraComponent = newCamera.GetComponent<Camera>();
    
    if (cameraComponent != null)
    {
        cameras[cameras.Length - 1] = cameraComponent;
    }
    else
    {
        Debug.LogWarning("No Camera component found for the existing camera GameObject.");
    }


    }
    public void AddPlayer(GameObject newPlayer)
    {
        //increase the size of the arrays for the new note
        Array.Resize(ref characters, characters.Length + 1);

        //add the new note to the arrays
        characters[characters.Length - 1] = newPlayer;

        characters[characters.Length - 1].SetActive(true);
        characters[characters.Length - 1].GetComponent<Walk_mechanic>().SetMovementEnabled(false);


    if (characters.Length == 1)
    {
        SetActiveCharacter(0);
    }
    }
}