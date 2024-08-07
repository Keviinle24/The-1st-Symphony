using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditstoStart : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Back to Start");
        SceneManager.LoadScene("StartGame");
    }
}
