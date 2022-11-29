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

    //Injure
    public GameObject injurerEnemy;

    JumperEnemyMove enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        rb.velocity = Vector2.right * bulletSpeed * player.transform.localScale.x;
        enemy = FindObjectOfType<JumperEnemyMove>();
     //   enemySR = enemy.GetComponent<SpriteRenderer>();
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

  

            StartCoroutine(flashInjureEnemy());
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            isColliderBusy = false;
        }
    }

    IEnumerator flashInjureEnemy()
    {
        enemy.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);

        enemy.GetComponent<SpriteRenderer>().color = Color.white;

    }








}
