using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

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

  

    //Ball values
    public GameObject standing, ball;
    public float waitToBall;
    private float ballCounter;
    public Animator ballAnimator;
    public GameObject ballBomb;

    //Dash Variables
    private float activeMoveSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f, dashSpeed = 15f;
    private float dashCoolCounter, timeSinceDash;

    //Death
    // Player Health
    public float playerHealth;
    public bool isDead = false;
    public float deathTime;
    public GameObject parentPlayer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();
       // FlipSprite();

        if(ball.activeSelf)
        {
            SetBallAnimation();
        }
        else if(standing.activeSelf)
        {
            SetStandingAnimation();
            Dash();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if( (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0) ) && standing.activeSelf)     
        {
            Fire();
            animator.SetTrigger("isShot");
        }

        TurnToBall();

        if (!isDead & playerHealth <= 0)
        {
            StartCoroutine(playerDeath(deathTime));

            isDead = true;

            animator.SetBool("isDeadAnim", isDead);

        }


    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(activeMoveSpeed * moveInput.x, rb.velocity.y);
    }


    void SetStandingAnimation()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }


    void SetBallAnimation()
    {
        ballAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }


    void Jump()
    {
        
        rb.velocity = Vector2.up * jumpForce;
    }

    /*
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

    */
    void Fire()
    {
        GameObject bulletProjectile = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;

        Destroy(bulletProjectile, 2);
    }


    //void TeleportFire()
    //{
    //    if(teleportFired == false && Input.GetKeyDown(KeyCode.J))
    //    {
    //        teleportFired = true;
    //        GameObject teleportProjectile = Instantiate(teleportBullet, firePoint.position, Quaternion.identity) as GameObject;
    //        teleportBulletTransform = teleportProjectile.transform;

    //        Destroy(teleportProjectile, 4);
    //    }
    //    else if(teleportFired == true && Input.GetKeyDown(KeyCode.J))
    //    {
    //        transform.position = new Vector3(teleportBulletTransform.transform.position.x, teleportBulletTransform.transform.position.y, transform.position.z);
    //        teleportFired = false;
    //    }
    //}


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


    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <= 0 && timeSinceDash <= 0)
            {
                activeMoveSpeed = dashSpeed;
                timeSinceDash = dashCooldown;
            }
        }

        if(timeSinceDash > 0)
        {
            timeSinceDash -= Time.deltaTime;

            if(timeSinceDash <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }   
    }


    void BallBomb()
    {
        if(ball.activeSelf && Input.GetKeyDown(KeyCode.M))
        {

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


    IEnumerator playerDeath(float deathTime)
    {
        //  GetComponent<dusmanhareket>().enabled = false;

        // death_jump();
        // GetComponent<CapsuleCollider2D>().enabled = false;
        //GetComponent<Animator>().enabled = false;

        parentPlayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<CapsuleCollider2D>().enabled = false;
        activeMoveSpeed = 0f;


        yield return new WaitForSeconds(deathTime);
        
        //if()
        
        
        
        Destroy(parentPlayer);


    }




}
