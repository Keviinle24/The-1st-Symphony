using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomOutandDOwn : MonoBehaviour
{
    public Camera[] cameras; 
    public float ZoomSize = 5f;      
    public float originalZoomSize = 8f;     
    public float zoomSpeed = 5f;         
    public float Y_Offset;

    private bool playerInsideTrigger = false;

    void Update()
    {
        if (playerInsideTrigger)
        {
        float targetSize = ZoomSize;
        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
            Vector3 targetPosition = new Vector3(cam.transform.position.x, cam.transform.position.y - Y_Offset * Time.deltaTime, cam.transform.position.z);
                cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * zoomSpeed);        }
    }
        
        else 
        {
            float targetSize = originalZoomSize;
        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
                Vector3 targetPosition = new Vector3(cam.transform.position.x, cam.transform.position.y + Y_Offset * Time.deltaTime, cam.transform.position.z);
                cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * zoomSpeed); 
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