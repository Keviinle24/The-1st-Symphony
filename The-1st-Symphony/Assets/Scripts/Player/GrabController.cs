using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public Transform originalParent;
    public float rayDist;
    public bool isHolding = false;
    public bool controllerT = false;
    private bool canGrab = true;

    void Update()
    {
        
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
    if (canGrab){
        if(grabCheck.collider != null && grabCheck.collider.tag == "box")
        {
            if((Input.GetKeyDown(KeyCode.E) || Input.GetAxisRaw("right trigger") > 0f) && !isHolding)
            {
                isHolding = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            if(Input.GetAxisRaw("right trigger") > 0f)
            {
                controllerT = true;
            }
        }
             if((isHolding && Input.GetKeyUp(KeyCode.E)) || (isHolding && controllerT && Input.GetAxisRaw("right trigger") == 0f) || !canGrab)
            {
                if (grabCheck.collider != null)
            {
                isHolding = false;
                controllerT = false;
                grabCheck.collider.gameObject.transform.parent = originalParent;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;  
            }   
            }}
        
        
    }

        public void SetGrabEnabled(bool isEnabled)
    {
        canGrab = isEnabled;
    }
    
    void OnDrawGizmos()
    {
        if (grabDetect != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(grabDetect.position, grabDetect.position + Vector3.right * rayDist);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(grabDetect.position + Vector3.right * rayDist, 0.1f);
        }
    }
}
