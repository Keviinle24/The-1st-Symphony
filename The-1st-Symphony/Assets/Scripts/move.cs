using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float bounceTime = 1f;
    private Rigidbody2D body;
    private Animator anim;
    private bool isJumping;  
 
    private bool grounded;
    // Counter for the number of jumps (for double jump)
    private int jumpCount;
   
    // Boolean to check if the character is touching a wall
    private bool isTouchingWall;
    private bool isBusy = false;

    // Called when the script instance is being loaded
    private void Awake()
    {
    
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Prevent rotation of the Rigidbody2D
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
 
        // Enable interpolation for smooth physics movement
        body.interpolation = RigidbodyInterpolation2D.Interpolate;

        EventManager.OnBouncePadHit += OnBouncePadHit;
  
    }

    private void OnDestroy() {
        EventManager.OnBouncePadHit -= OnBouncePadHit;
       
    }

    private void OnBouncePadHit(string tag, BouncePad bp) {
        if (gameObject.CompareTag(tag)) {
            StartCoroutine(BounceRoutine(bp));
        }
    }

 

    private IEnumerator BounceRoutine(BouncePad bp) {
        isBusy = true;
        body.AddForce(bp.Directions * bp.Bounce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(bounceTime);
        isBusy = false;
    }


    // Called once per frame
    private void Update()
    {
        if (isBusy) return;
        
        // Get horizontal input (A/D keys or Left/Right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Set the horizontal velocity based on input and speed
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip the character to face right
        if (horizontalInput > 0)

            /*The Transform component is responsible for storing and manipulating the position, 
            rotation, and scale of the game object*/
            transform.localScale = new Vector3(1, 1, 1);        


        // Flip the character to face left
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Check if the jump button (space bar) is pressed
        if (Input.GetButtonDown("Jump"))
        {
            // Nested for-loop to allow jump if grounded or jump again if jumpCount is 1 to double jump
            if (grounded || jumpCount < 2)
            {
                // Set vertical velocity for jumping while horizontal velocity is unchanged 
                body.velocity = new Vector2(horizontalInput, jumpingPower);
                jumpCount++;
                isJumping = true;  
            }
        }


        // Apply downward velocity if touching a wall and moving forward while in the air
        if (isTouchingWall && !grounded && horizontalInput != 0)
        {
            body.velocity = new Vector2(horizontalInput, body.velocity.y - 0.5f);
        }

        // Check if the jump button is released and character is still moving upwards
        if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            // Decrease the vertical velocity to be less floaty
            body.velocity = new Vector2(horizontalInput, body.velocity.y * 0.5f); // Adjust descent speed
        }

        if (isJumping && body.velocity.y <= 0)
        {
            body.velocity = new Vector2(horizontalInput, body.velocity.y * 0.5f); // Adjust descent speed
            isJumping = false; // End jump state 
        }
        // Set the walk animation based on horizontal input
        anim.SetBool("walk", horizontalInput != 0);
        // anim.SetBool("jump, body.velocity.y > 0");
        // anim.SetBool("falling, body.velocity.y <= 0");
 
    }


    // Called when the collider enters a collision with another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the ground or a pushable object
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "pushable")
        {
            grounded = true;
            jumpCount = 0;
            isJumping = false; 
        }

        // Check if the collision is with a wall
        if (collision.gameObject.tag == "Wall")
        {
           
            isTouchingWall = true;
        }
    }

    // Called when the collider exits a collision with another collider
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision was with the ground
        if (collision.gameObject.tag == "Ground")
        {
            // Set grounded to false
            grounded = false;
        }

        // Check if the collision was with a wall
        if (collision.gameObject.tag == "Wall")
        {
            // Set isTouchingWall to false
            isTouchingWall = false;
        }
    }
}
