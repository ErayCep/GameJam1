using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    RealMoney RealMoneyObject;
    private void Start()
    {
        RealMoneyObject = FindObjectOfType<RealMoney>();
        PlayerMovement.instance.doubleJumpUnlocked  = RealMoneyObject.GetComponent<RealMoney>().doubleJumpStore;
    }
    void Update()
    {
        if(PlayerMovement.instance.doubleJumpUnlocked == true)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.instance.doubleJumpUnlocked = true;
            RealMoneyObject.GetComponent<RealMoney>().doubleJumpStore= true;
            Destroy(gameObject);
        }
    }
}
