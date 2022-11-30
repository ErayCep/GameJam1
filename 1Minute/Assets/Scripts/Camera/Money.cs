using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;
public class Money : MonoBehaviour
{


    public float gold = 0f;
    
    public float jumperGold = 10f;

    

    public GameObject[] coinObject  ;
  

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

    //TextMeshPro
    public TextMeshProUGUI coinstext;

    void Start() 
    {
       
        
    }

     void Update()
    {
        coinstext.text = gold.ToString();
  
        
        EarnCoinJumper();
        EarnCoinJumper1();
        EarnCoinJumper2();


    }

    IEnumerator isDeadJumperWait()   // Jumper destroy two seconds after dead.
    {
      
    
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);

        isDestroyedJumper = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

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
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);

        isDestroyedJumper1 = true;
        
        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

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
        coinObject[0].SetActive(true);   
        

        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper2 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

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
