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

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "box")
        {
            if((Input.GetKeyDown(KeyCode.E) || Input.GetAxisRaw("right trigger") > 0f) && !isHolding)
            {
                isHolding = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
             if(isHolding && (Input.GetKeyUp(KeyCode.E) || Input.GetAxisRaw("right trigger") == 0f))
            {
                isHolding = false;
                grabCheck.collider.gameObject.transform.parent = originalParent;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;  
                
            }
        
    }
}
