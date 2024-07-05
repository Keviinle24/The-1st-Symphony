using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{


 void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("InTrigger " + other.gameObject.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public float rotationSpeed = 50f; 

   // comment out if no want to spin (to comment out use //)
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}


