using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2 : MonoBehaviour
{


 void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("InTrigger " + other.gameObject.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
