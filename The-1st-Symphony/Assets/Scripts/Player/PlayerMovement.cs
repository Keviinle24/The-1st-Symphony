using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_mechanic : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 15f;
    public float climbSpeed = 15f;
    public float jumpingPower = 1f;
    private bool isFacingRight = true;
    private bool isClimbing;
    private float originalSpeed;
    private float originalJumpingPower;
    private float originalClimbSpeed;
    private Transform originalParent;
    public Transform spawnPoint;

    private bool canMove = true;

    private bool swinging = false;

    private Transform currentSwingable;
    public Vector2 ropeVelocityGrabbed;

   

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Transform GroundCheck1;
    [SerializeField] private LayerMask platform;
    [SerializeField] private AudioSource[] audioplayers;

    private HashSet<GameObject> Ladders = new HashSet<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
        originalSpeed = speed;
        originalJumpingPower = jumpingPower;
        originalClimbSpeed = climbSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

     if(Input.GetButtonDown("Jump") && isGrounded())
     {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
     }

    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
    }
        
        Flip();

        //Ladder
        if(Ladders.Count > 0 && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        else if (Ladders.Count <= 0f)
        {
            StartCoroutine(IsClimbingBuffer());
        }
        }

        if (swinging == true){
        
        transform.position = currentSwingable.position;
        if(Input.GetButtonUp("Jump") && swinging == true)
        {
            swinging = false;
            rb.velocity = new Vector2(currentSwingable.GetComponent<Rigidbody2D>().velocity.x, currentSwingable.GetComponent<Rigidbody2D>().velocity.y + 10);
        }
        }
    }

    private void FixedUpdate(){
        if(canMove){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
        }
        }
    }

    private bool isGrounded()
    {
        if (GroundCheck1 != null && isGrounded2()){
        return Physics2D.OverlapCircle(GroundCheck1.position, 0.2f, platform);
        }
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, platform);

    }

    private bool isGrounded2(){
        return Physics2D.OverlapCircle(GroundCheck1.position, 0.2f, platform);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator IsClimbingBuffer()
    {
        yield return new WaitForSeconds(.4f);
    
    isClimbing = false;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger"))
        {
            RespawnPlayer();
        }
        if (collision.CompareTag("Ladder"))
        {
            Ladders.Add(collision.gameObject);
        }
        if (collision.CompareTag("Rope")){
        Rigidbody2D ropeRigidbody = collision.GetComponent<Rigidbody2D>();
        
        if (ropeRigidbody != null)
        {            
            ropeRigidbody.velocity = ropeVelocityGrabbed;
            swinging = true;
            currentSwingable = collision.transform;
        }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Ladders.Remove(collision.gameObject);

        }

    }

    void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }


    public void SetParent(Transform newParent, float platSpeed, float platJump)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
        speed = platSpeed;
        jumpingPower = platJump;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
        speed = originalSpeed;
        jumpingPower = originalJumpingPower;
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        canMove = isEnabled;
    }

    public void ChangeSpeed( float NewSpeed, float NewJump, float NewClimb)
    {
        speed = NewSpeed;
        jumpingPower = NewJump;
        climbSpeed = NewClimb;
    }

    public void ResetSpeed()
    {
        speed = originalSpeed;
        jumpingPower = originalJumpingPower;
        climbSpeed = originalJumpingPower;
    }

}