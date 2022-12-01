using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    //PlayerMovement player;
    ParentScript player;
    BossBattle boss;

    public float bulletSpeed = 15f;

    //Damage to Enemy
    public float damageToEnemy;
    public int damageToBoss = 5;
    bool isColliderBusy = false;

    public GameObject impact;


    JumperEnemyMove enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //player = FindObjectOfType<PlayerMovement>();
        //rb.velocity = Vector2.right * bulletSpeed * player.transform.localScale.x;

        player = FindObjectOfType<ParentScript>();
        rb.velocity = Vector2.right * bulletSpeed * player.transform.localScale.x;

        enemy = FindObjectOfType<JumperEnemyMove>();
     //   enemySR = enemy.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !isColliderBusy)
        {
            isColliderBusy = true;
            other.GetComponent<JumperEnemyMove>().getDamage(damageToEnemy);

            StartCoroutine(flashInjureEnemy());
        }

        IEnumerator flashInjureEnemy()
        {


            if (other.tag == "Enemy" && !(enemy.isDeadEnemy))
            {
                other.GetComponent<SpriteRenderer>().color = Color.red;
             
                yield return new WaitForSeconds(0.2f);

                other.GetComponent<SpriteRenderer>().color = Color.white;

            }

        }

  //    GetComponent<SpriteRenderer>().color = Color.red;

//=======
        if (other.tag == "Boss")
        {
            BossHealthController.instance.TakeDamage(damage: damageToBoss);
        }

        Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
//>>>>>>> Stashed changes

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            isColliderBusy = false;
        }

        // B U L L E T    R E D
    }
}
