using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundlayer;

    private Vector3 startingPoint;
    private Vector3 respawningPoint;
    private bool facingRight = true;
    private float horizontalMovement;
    private float verticalMovement;
    private AudioSource audioSource;

    public float jumpForce = 7f;
    public float walkingSpeed = 8f;

    void Start()
    {
        // to respawn player after fail
        startingPoint = transform.position;
        respawningPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        // VERTICAL MOVEMENT
        if (verticalMovement > 0f && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(rb.velocity.y < 0f)
        {
            rb.gravityScale = 3f;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        if(rb.velocity.x == 0f && IsGrounded())
        {
            audioSource.Play();
        }
        // check sprite direction
        Flip();
    }

    private void FixedUpdate()
    {
        // HORIZONTAL MOVEMENT
        rb.velocity = new Vector2(horizontalMovement * walkingSpeed, rb.velocity.y);
        // walking animation and sound ----------------------
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundlayer);
    }

    private void Flip()
    {
        if(facingRight && horizontalMovement < 0f || !facingRight && horizontalMovement > 0f)
        {
            facingRight = !facingRight;
            transform.Rotate(0f,180f,0f);
        }
    }

    //damage handling
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            StartCoroutine(WaitBeforeRespawn());
        }
        else if(collision.tag == "CheckPoint")
        {
            respawningPoint = transform.position;
        }
        else if (collision.tag == "EndPoint")
        {
            // ending cutscene --------------------------
        }
    }

    private IEnumerator WaitBeforeRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = respawningPoint;
    }

    public void Die()
    {
        StartCoroutine (WaitBeforeRespawn());
    }
}
