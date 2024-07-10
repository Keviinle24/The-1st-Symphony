using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float checkDistance = 0.05f;

    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;

    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;


    void Start()
    {
        targetWaypoint = waypoints[0];
    }

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
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
        targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
        return waypoints[currentWaypointIndex];
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
        platformMovement.SetParent(transform);
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

}
