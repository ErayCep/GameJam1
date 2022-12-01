using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    public float jumpForce = 10f;

    public Transform groundCheck;
    public float checkRadius = 0.4f;
    public LayerMask ground;

    public Animator animator;

    private bool isGrounded;

    Vector2 moveInput;

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        SetAnimation();
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveInput.x, rb.velocity.y);
    }

    void SetAnimation()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}