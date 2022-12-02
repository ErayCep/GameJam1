using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBombPowerUp : MonoBehaviour
{

    RealMoney RealMoneyObject;

    private void Start()
    {
        RealMoneyObject = FindObjectOfType<RealMoney>();
        ParentScript.instance.ballBombUnlocked  = RealMoneyObject.GetComponent<RealMoney>().ballBombStore;
    }

    void Update()
    {
        if(ParentScript.instance.ballBombUnlocked == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            ParentScript.instance.ballBombUnlocked = true;
            RealMoneyObject.GetComponent<RealMoney>().ballBombStore = true; 
        }
    }


}

