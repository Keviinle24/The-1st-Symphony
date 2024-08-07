using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public Camera[] cameras; 
    public float ZoomSize = 5f;      
    public float originalZoomSize = 8f;     
    public float zoomSpeed = 5f;         

    private bool playerInsideTrigger = false;

    void Update()
    {
        if (playerInsideTrigger)
        {
        float targetSize = ZoomSize;
        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }
        
        else 
        {
            float targetSize = originalZoomSize;
        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }
    }        
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            playerInsideTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WholeNote") || other.CompareTag("HalfNote") || other.CompareTag("EightNote") || other.CompareTag("QuarterNote"))
        {
            playerInsideTrigger = false;
        }
    }
}