using System.Collections;
using System.Collections.Generic;
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
    private Animator animator;

    public float jumpForce = 7f;
    public float walkingSpeed = 8f;
    public GameObject deathEffect;

    void Start()
    {
        // to respawn player after fail
        startingPoint = transform.position;
        respawningPoint = transform.position;
        animator = GetComponent<Animator>();
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

        // check sprite direction
        Flip();
    }

    private void FixedUpdate()
    {
        // HORIZONTAL MOVEMENT
        rb.velocity = new Vector2(horizontalMovement * walkingSpeed, rb.velocity.y);
        if(Mathf.Abs(horizontalMovement) > 0f && IsGrounded())
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
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
    }

    private IEnumerator WaitBeforeRespawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = respawningPoint;
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        StartCoroutine (WaitBeforeRespawn());
    }
}
