using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentScript : MonoBehaviour
{
    public static ParentScript instance;

    Rigidbody2D ManRigidBody;
    public bool FaceRight = true;

    public Slider slider;

    public GameObject standing, ball;
    public float waitToBall;
    private float ballCounter;

    public bool ballUnlocked, ballBombUnlocked, doubleJumpUnlocked;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ManRigidBody = GetComponent<Rigidbody2D>();
        slider.maxValue = PlayerMovement.instance.playerHealth;
        slider.value = PlayerMovement.instance.playerHealth;
    }

    void Update()
    {
        if(ballUnlocked == true)
        {
            TurnToBall();
        }
    }

    public void FixedUpdate()
    {

        if (ManRigidBody.velocity.x< 0 && FaceRight)
        {
            Faceturn();
        }
        else if (ManRigidBody.velocity.x>0 && !FaceRight)
        {
            Faceturn();
        }

    }

    void TurnToBall()
    {
        if (!ball.activeSelf)
        {
            if (Input.GetAxisRaw("Vertical") < -.9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter <= 0)
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
            if (Input.GetAxisRaw("Vertical") > .9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter <= 0)
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

    void Faceturn()
    {
        
        FaceRight = !FaceRight;

        Vector3 boyut3 = transform.localScale;

        boyut3.x *= -1;

        transform.localScale = boyut3;


    }


}
