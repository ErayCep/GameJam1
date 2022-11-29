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

    //Teleport Shooting
    private bool teleportFired;
    private Transform teleportBulletTransform;
    public GameObject teleportBullet;

    // Player Health
    public float playerHealth;
    public bool isDeath = false;

    //Ball values
    public GameObject standing, ball;
    public float waitToBall;
    private float ballCounter;

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();
        SetAnimation();
        FlipSprite();

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
       // TeleportFire();
        if(Input.GetKeyDown(KeyCode.J) ||Input.GetMouseButtonDown(0))     
        {
            Fire();
            animator.SetTrigger("isShot");
        }

        TurnToBall();

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

        //Destroy(bulletProjectile, 2);
    }

    void TeleportFire()
    {
        if(teleportFired == false && Input.GetKeyDown(KeyCode.J))
        {
            teleportFired = true;
            GameObject teleportProjectile = Instantiate(teleportBullet, firePoint.position, Quaternion.identity) as GameObject;
            teleportBulletTransform = teleportProjectile.transform;

            Destroy(teleportProjectile, 4);
        }
        else if(teleportFired == true && Input.GetKeyDown(KeyCode.J))
        {
            transform.position = new Vector3(teleportBulletTransform.transform.position.x, teleportBulletTransform.transform.position.y, transform.position.z);
            teleportFired = false;
        }
    }

    void TurnToBall()
    {
        if(!ball.activeSelf)
        {
            if(Input.GetAxisRaw("Vertical") < -.9f)
            {
                ballCounter -= Time.deltaTime;
                if(ballCounter <= 0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
        }
        else
        {
            if(Input.GetAxisRaw("Vertical") > .9f)
            {
                ballCounter -= Time.deltaTime;
                if(ballCounter <= 0)
                {
                    ball.SetActive(false);
                    standing.SetActive(true);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
        }
    }

    public void getDamage(float damageToPlayer)
    {
        if (playerHealth - damageToPlayer >= 0)

        {
            playerHealth -= damageToPlayer;
        }
        else

        {
            playerHealth = 0;
           
        }

    }


    /*
        IEnumerator getInjure()
        {
      GetComponent<SpriteRenderer>().material.color = Color.red;
              yield return new WaitForSeconds(1f);
      GetComponent<SpriteRenderer>().material.color = Color.white;       
   // Debug.Log("ah bu ac?d?");
        }
    
    */




}
