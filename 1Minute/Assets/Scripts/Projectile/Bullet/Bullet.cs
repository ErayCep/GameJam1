using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement player;
    public float bulletSpeed = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        rb.velocity = Vector2.right * bulletSpeed * player.transform.localScale.x;
    }

    void Update()
    {
        
    }
}
