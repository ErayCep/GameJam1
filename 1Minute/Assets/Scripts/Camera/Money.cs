using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{


    public float gold = 0f;
    
    public float jumperGold = 10f;

    

   // public GameObject emptyObject;
  

    public GameObject [] objectJumper;

    // Enemy 0
    public bool isDeadJumper = false;
    public bool  isDestroyedJumper = false;
    bool waitEarn = true;
    //Enemy 1
    public bool isDeadJumper1 = false;
    public bool isDestroyedJumper1 = false;
    bool waitEarn1 = true;
    //Enemy 2
    public bool isDeadJumper2 = false;
    public bool isDestroyedJumper2 = false;
    bool waitEarn2 = true;
    
    void Start() 
    {
       
        
    }

     void Update()
    {
        EarnCoinJumper();
        EarnCoinJumper1();
        EarnCoinJumper2();


    }

    IEnumerator isDeadJumperWait()   // Jumper destroy two seconds after dead.
    {
            yield return new WaitForSeconds(2.1f);
            isDestroyedJumper = true;
    }

    void EarnCoinJumper()
    {
       
        if (!isDeadJumper)
        {
            isDeadJumper = objectJumper[0].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper &&  waitEarn && !isDestroyedJumper)
        {



            StartCoroutine(isDeadJumperWait());

        }
        if (isDestroyedJumper && waitEarn)
        {
            gold += jumperGold;
            waitEarn = false;
        }


    }

    IEnumerator isDeadJumperWait1()   
    {
        yield return new WaitForSeconds(2.1f);
        isDestroyedJumper1 = true;
    }
    void EarnCoinJumper1()
    {

        if (!isDeadJumper1)
        {
            isDeadJumper1 = objectJumper[1].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper1 &&  waitEarn1 && !isDestroyedJumper1)
        {



            StartCoroutine(isDeadJumperWait1());

        }
        if (isDestroyedJumper1 && waitEarn1)
        {
            gold += jumperGold;
            waitEarn1 = false;
        }


    }

    IEnumerator isDeadJumperWait2()   
    {
        yield return new WaitForSeconds(2.1f);
        isDestroyedJumper2 = true;
    }
    void EarnCoinJumper2()
    {

        if (!isDeadJumper2)
        {
            isDeadJumper2 = objectJumper[2].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDeadJumper2 &&  waitEarn2 && !isDestroyedJumper2)
        {



            StartCoroutine(isDeadJumperWait2());

        }
        if (isDestroyedJumper2 && waitEarn2)
        {
            gold += jumperGold;
            waitEarn2 = false;
        }


    }




}
