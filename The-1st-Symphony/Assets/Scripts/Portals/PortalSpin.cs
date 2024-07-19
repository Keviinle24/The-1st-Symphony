using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpin : MonoBehaviour
{

    public float rotateSpeed = 50f; // Speed of rotation
    public float scaleXSpeed = 0.1f; // Speed of scale change for X axis
    public float maxScaleX = 4f; // Maximum scale factor for X axis
    public float minScaleX = 2f; // Minimum scale factor for X axis
    public float scaleYSpeed = 0.1f; // Speed of scale change for Y axis
    public float maxScaleY = 4f; // Maximum scale factor for Y axis
    public float minScaleY = 2f; // Minimum scale factor for Y axis

    void Update()
    {
        // Rotate the square around its center
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Change the scale of the square on X axis gradually
        float scaleXFactor = Mathf.PingPong(Time.time * scaleXSpeed, maxScaleX - minScaleX) + minScaleX;
        
        // Change the scale of the square on Y axis gradually
        float scaleYFactor = Mathf.PingPong(Time.time * scaleYSpeed, maxScaleY - minScaleY) + minScaleY;

        // Apply the independent scales to the square
        transform.localScale = new Vector3(scaleXFactor, scaleYFactor, 1f);
    }
}
