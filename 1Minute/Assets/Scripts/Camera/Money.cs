using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{


    public float gold = 7f;
    
    public float jumperGold = 10f;

    

   // public GameObject emptyObject;
    bool waitEarn = true;

    public GameObject [] objectJumper;

    public bool isDeadJumper = false;
    public bool  isDestroyedJumper = false;
    void Start() 
    {
       
        
    }

     void Update()
    {

        if (!isDeadJumper)
        {
            isDeadJumper = objectJumper[0].GetComponent<JumperEnemyMove>().isDeadEnemy;
        }
        else
        {

        }

        if (isDestroyedJumper)
        {
            gold += jumperGold;
            isDestroyedJumper = false;
        }
        if (waitEarn)
        {
            StartCoroutine(isDeadJumperWait());
        }
    
    }

    IEnumerator isDeadJumperWait()   // Jumper destroy two seconds after dead.
    {
        if (isDeadJumper)
        {
          //  objectJumper[0] = emptyObject;
            yield return new WaitForSeconds(3f);
            isDestroyedJumper = true;
            waitEarn = false;
        }
    }



    // void Update()
    //{

    //    isDeadJumper = jumperObject[0].GetComponent<JumperEnemyMove>().isDeadEnemy;

    //    if (isDeadJumper & waitEarn)
    //    {
    //        gold += jumperGold;

    //        isDeadJumper=false;
    //        waitEarn=false;
    //    }
    //    StartCoroutine(OnceEarn());
    //}

    //IEnumerator OnceEarn() 
    //{


    //    if (isDeadJumper)
    //    {
    //        jumperObject[0] = emptyObject;
    //        yield return new WaitForSeconds(10f);

    //        waitEarn=true;
    //    }
    //}



}
