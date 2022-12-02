using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using TMPro;
public class Money : MonoBehaviour
{
    RealMoney RealMoneyObject;

    public float gold ;

    public float RealMoneyCome;

    public float jumperGold = 10f;
    public float walkerGold = 20f;

    public GameObject heroObject;

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
    //WALKER
    public bool isDeadJumper3 = false;
    public bool isDestroyedJumper3 = false;
    bool waitEarn3 = true;
    //WALKER1
    public bool isDeadJumper4 = false;
    public bool isDestroyedJumper4 = false;
    bool waitEarn4 = true;
    //WALKER2
    public bool isDeadJumper5 = false;
    public bool isDestroyedJumper5 = false;
    bool waitEarn5 = true;
    //WALKER3
    public bool isDeadJumper6 = false;
    public bool isDestroyedJumper6 = false;
    bool waitEarn6 = true;



    //TextMeshPro
    public TextMeshProUGUI coinstext;

    void Start() 
    {
      StartCoroutine(Countdown60());

        RealMoneyObject = FindObjectOfType<RealMoney>();

        RealMoneyCome = RealMoneyObject.GetComponent<RealMoney>().realGold;

    }

     void Update()
    {
        coinstext.text = RealMoney.Instance.realGold.ToString();
  
        
        EarnCoinJumper();
        EarnCoinJumper1();
        EarnCoinJumper2();
        EarnCoinJumper3();
        EarnCoinJumper4();
        EarnCoinJumper5();
        EarnCoinJumper6();


    }

    IEnumerator Countdown60()
    {
        yield return new WaitForSeconds(60f);

        heroObject.GetComponent<PlayerMovement>().playerHealth = 0;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    //  E N E M I E S
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
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
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
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
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
         
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn2 = false;
        }


    }
    //     W  A  L  K  E  R


    IEnumerator isDeadJumperWait3()
    {
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper3 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper3()
    {

        if (!isDeadJumper3)
        {
            isDeadJumper3 = objectJumper[3].GetComponent<WalkerHealthController>().isDeadWalker;
        }
        else
        {

        }

        if (isDeadJumper3 &&  waitEarn3 && !isDestroyedJumper3)
        {



            StartCoroutine(isDeadJumperWait3());

        }
        if (isDestroyedJumper3 && waitEarn3)
        {
         
            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn3 = false;
        }


    }



    IEnumerator isDeadJumperWait4()
    {
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper4 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper4()
    {

        if (!isDeadJumper4)
        {
            isDeadJumper4 = objectJumper[4].GetComponent<WalkerHealthController>().isDeadWalker;
        }
        else
        {

        }

        if (isDeadJumper4 &&  waitEarn4 && !isDestroyedJumper4)
        {



            StartCoroutine(isDeadJumperWait4());

        }
        if (isDestroyedJumper4 && waitEarn4)
        {

            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn4 = false;
        }


    }


    IEnumerator isDeadJumperWait5()
    {
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper5 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper5()
    {

        if (!isDeadJumper5)
        {
            isDeadJumper5 = objectJumper[5].GetComponent<WalkerHealthController>().isDeadWalker;
        }
        else
        {

        }

        if (isDeadJumper5 &&  waitEarn5 && !isDestroyedJumper5)
        {



            StartCoroutine(isDeadJumperWait5());

        }
        if (isDestroyedJumper5 && waitEarn5)
        {

            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn5 = false;
        }


    }


    IEnumerator isDeadJumperWait6()
    {
        coinObject[0].SetActive(true);


        yield return new WaitForSeconds(1.3f);
        coinstext.color = new Color32(255, 255, 255, 255);
        isDestroyedJumper6 = true;

        yield return new WaitForSeconds(15f);
        coinstext.color = new Color32(255, 255, 255, 0);
        coinObject[0].SetActive(false);

    }
    void EarnCoinJumper6()
    {

        if (!isDeadJumper6)
        {
            isDeadJumper6 = objectJumper[6].GetComponent<WalkerHealthController>().isDeadWalker;
        }
        else
        {

        }

        if (isDeadJumper6 &&  waitEarn6 && !isDestroyedJumper6)
        {



            StartCoroutine(isDeadJumperWait6());

        }
        if (isDestroyedJumper6 && waitEarn6)
        {

            RealMoneyCome += jumperGold;
            RealMoneyObject.GetComponent<RealMoney>().realGold = RealMoneyCome;
            waitEarn6 = false;
        }


    }



}
