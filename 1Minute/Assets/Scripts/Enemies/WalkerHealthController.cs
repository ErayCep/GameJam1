using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerHealthController : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth = 50;

    public GameObject walker;

    //dead
    public bool isDeadWalker = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        StartCoroutine(WalkerDestroy());
        

    }


    IEnumerator WalkerDestroy()
    {
        if (currentHealth <= 0)
        {
            isDeadWalker = true;
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;

           
        }
    }
}
