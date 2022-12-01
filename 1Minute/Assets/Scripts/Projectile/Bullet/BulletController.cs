using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 15f;

    public int damage = 10;

    BossHealthController boss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * PlayerMovement.instance.transform.localScale.x * moveSpeed;
        boss = FindObjectOfType<BossHealthController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boss")
        {
            boss.TakeDamage(damage);
        }
    }
}
