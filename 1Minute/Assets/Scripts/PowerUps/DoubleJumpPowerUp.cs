using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.instance.doubleJumpUnlocked = true;
            Destroy(gameObject);
        }
    }
}
