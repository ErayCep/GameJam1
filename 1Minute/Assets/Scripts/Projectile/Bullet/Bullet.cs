using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement player;
    public float bulletSpeed = 15f;

    //Damage to Enemy
    public float damageToEnemy;
    bool isColliderBusy = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        rb.velocity = Vector2.right * bulletSpeed * player.transform.localScale.x;
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !isColliderBusy)

        {
            isColliderBusy=true;
            collision.GetComponent<JumperEnemyMove>().getDamage(damageToEnemy);

            Debug.Log("girdi mermi");


        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            isColliderBusy = false;
        }


    }










}
