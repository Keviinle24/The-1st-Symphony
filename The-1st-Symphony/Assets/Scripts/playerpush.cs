using UnityEngine;  


public class playerpush : MonoBehaviour {  

    public float distance = 5f; // Distance for the raycast to detect pushable objects.
    public LayerMask boxMask; // Layer mask to filter which objects the raycast can hit.
    private Rigidbody2D rb;
    GameObject box; // Variable to store the reference to the pushable box.

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        float horizontalInput = Input.GetAxis("Horizontal");

        Physics2D.queriesStartInColliders = false; //When set to false, the raycast will ignore the collider it starts from. Make sure to not mark player in boxMask as well
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask); 
        // Casts a ray from the player's position to the right, filtered by the boxMask, up to the specified distance.

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKey(KeyCode.E)) {
            // Checks if the raycast hit something, if that something has the tag "pushable", and if the "E" key is being pressed.

            box = hit.collider.gameObject; // Stores the reference to the hit pushable box.
            box.GetComponent<FixedJoint2D>().enabled = true;  
            box.GetComponent<boxpull>().beingPushed = true;  
            box.GetComponent<FixedJoint2D>().connectedBody = rb; 
            rb.velocity = new Vector2(horizontalInput * 200, rb.velocity.y);
          
            if (Input.GetButtonDown("Jump"))
            {
                 rb.velocity = new Vector2(horizontalInput * 200, rb.velocity.y * 25);
                 
            }
            // Connects the box's FixedJoint2D to the player's Rigidbody2D, so they move together.
            
        } else if (Input.GetKeyUp(KeyCode.E)) {
            // Checks if the "E" key was released.

            box.GetComponent<FixedJoint2D>().enabled = false; // Disables the FixedJoint2D component on the box.
            box.GetComponent<boxpull>().beingPushed = false; // Sets the beingPushed property of the boxpull script to false.
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow; // Sets the Gizmos color to yellow.

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        // Draws a yellow line in the Scene view representing the raycast for debugging purposes.
    }
}
