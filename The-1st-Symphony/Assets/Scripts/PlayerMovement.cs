using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_mechanic : MonoBehaviour
{
    private float horizontal;
    public float speed = 15f;
    public float jumpingPower = 1f;
    private bool isFacingRight = true;
    private float originalSpeed;
    private Transform originalParent;
    public Transform spawnPoint;

   

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask platform;
    [SerializeField] private AudioSource[] audioplayers;


    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

     if(Input.GetButtonDown("Jump") && isGrounded())
     {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
     }

    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
    }

        Flip();

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

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        transform.position = spawnPoint.position;
    }


    public void SetParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
        speed = originalSpeed * 2;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
        speed = originalSpeed;
    }
}