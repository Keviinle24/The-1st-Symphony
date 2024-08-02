using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedPlat : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    public float playerSpeed = 15f;
    public float playerJump = 30f;

    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;

    private bool isActive = false;
     void OnDrawGizmos() 
    {
        if(platform!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
        transform.position = Vector2.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }

 private void OnCollisionEnter2D(Collision2D other)
 {
    ContactPoint2D contact = other.GetContact(0);
            Vector2 platformTop = transform.position + Vector3.up * (transform.localScale.y / 2); 
            if (contact.point.y > platformTop.y)
            {
    var platformMovement = other.collider.GetComponent<Walk_mechanic>();
    if (platformMovement != null) 
    {   
        if (other.gameObject.CompareTag("HalfNote") || other.gameObject.CompareTag("WholeNote") || other.gameObject.CompareTag("EightNote") || other.gameObject.CompareTag("QuarterNote"))
    {
        platformMovement.SetParent(transform, playerSpeed, playerJump);
    }

 }
 }
 }

 private void OnCollisionExit2D(Collision2D other)
 {
    var platformMovement = other.collider.GetComponent<Walk_mechanic>();
    if (platformMovement != null) 
    {
        platformMovement.ResetParent();
    }
 }

     public void ActivatePlatform()
    {
        isActive = true;
    }

    public void DeactivatePlatform()
    {
        isActive = false;
    }

}

