using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump_mechanic : MonoBehaviour
{
    private float horizontal;
    public float speed = 4f;
    public float jumpingPower = 1f;
    private bool isFacingRight = true;
    private Transform originalParent;

    private bool doubleJump; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask platform;
    [SerializeField] private AudioSource[] audioplayers;


    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

    if (isGrounded() && !Input.GetButton("Jump"))
    {
        doubleJump = false;
    }

     if(Input.GetButtonDown("Jump"))
     {
        if (isGrounded() || doubleJump)
        
     {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        doubleJump = !doubleJump;
     }
     }
    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }

        //Flip();

    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, platform);
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


// public void OnCollisionEnter2D(Collision2D collision)
// {
//     if(collision.gameObject.tag == "CollisionTagSound"){
//         audioplayers[0].Play();
//     }

//     else if(collision.gameObject.tag == "CollisionTagGnote"){
//         audioplayers[1].Play();
//     }

//      if(collision.gameObject.tag == "ColorChange")
//         {
//             collision.gameObject.GetComponent<SpriteRenderer>().material.color = Color.cyan;
//         }

// }

    public void SetParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
    }
}