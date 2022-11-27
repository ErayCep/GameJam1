using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Props
    public Rigidbody2D rb;

    //Movement Variables
    public float moveSpeed = 10f;
    Vector2 moveInput;

    //Animation
    public Animator animator;

    //Jump variables
    public float jumpForce = 10f;
    private bool isGrounded;
    public LayerMask ground;
    public Transform groundCheck;
    private float checkRadius = 0.4f;

    //Shooting Props
    public Transform firePoint;
    public GameObject bullet;


    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();
        SetAnimation();
        FlipSprite();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            Fire();
            animator.SetTrigger("isShot");
        }
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

    void Jump()
    {
        
        rb.velocity = Vector2.up * jumpForce;
    }

    void FlipSprite()
    {
        if(moveInput.x == 1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(moveInput.x == -1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void Fire()
    {
        GameObject bulletProjectile = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;

        Destroy(bulletProjectile, 2);
    }
}
