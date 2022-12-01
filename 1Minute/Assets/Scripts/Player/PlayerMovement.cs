using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isGrounded;                         // private to public
    public LayerMask ground;
    public Transform groundCheck;
    private float checkRadius = 0.4f;

    //Shooting Props
    public Transform firePoint;
    public GameObject bullet;

    //Bullet Variables
    public GameObject[] bullets;
    private int activeBulletIndex = 0;

    public GameObject standing;

    public bool doubleJumpUnlocked = false;

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

    private bool canDoubleJump = true;

    private void Awake()
    {
        instance = this;

        bullet = bullets[activeBulletIndex];
    }

    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        Move();

        if(standing.activeSelf)
        {
            SetStandingAnimation();
            Dash();
        }

        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded || (canDoubleJump && doubleJumpUnlocked)))
        {
            if(isGrounded)
            {
                canDoubleJump = true;
            }
            else
            {
                animator.SetTrigger("doubleJump");
                canDoubleJump = false;  
            }

            Jump();
        }

        if( (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0) ) && standing.activeSelf)     
        {
            Fire();
            animator.SetTrigger("isShot");
        }

        if (!isDead & playerHealth <= 0)
        {
            StartCoroutine(playerDeath(deathTime));

            isDead = true;

            animator.SetBool("isDeadAnim", isDead);
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            activeBulletIndex++;

            if(activeBulletIndex > bullets.Length - 1)
            {
                activeBulletIndex = 0;
            }
            SwitchBullet();
        }

        if(playerHealth == 0)
        {
            StartCoroutine(DeathSpawn());
        }
        animator.SetBool("isGrounded", isGrounded);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BallUnlock")
        {
            ParentScript.instance.ballUnlocked = true;
        }
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(activeMoveSpeed * moveInput.x, rb.velocity.y);
    }

    void SwitchBullet()
    {
        bullet = bullets[activeBulletIndex];
    }


    void SetStandingAnimation()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    void Jump()
    {
        
        rb.velocity = Vector2.up * jumpForce;
    }

    void Fire()
    {
        GameObject bulletProjectile = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;

        Destroy(bulletProjectile, 2);
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
        parentPlayer.GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<CapsuleCollider2D>().enabled = false;
        activeMoveSpeed = 0f;

        yield return new WaitForSeconds(deathTime);

        Destroy(parentPlayer);
    }

    IEnumerator DeathSpawn()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
