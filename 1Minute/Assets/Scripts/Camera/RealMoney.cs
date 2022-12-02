using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMoney : MonoBehaviour
{
        
    public float realGold ;

    public float playerHealthStore;

    public float bulletDamageStore;
    public int bulletBossDamageStore;

    public bool ballStore;
    public bool ballBombStore;
    public bool doubleJumpStore ;

    public static RealMoney Instance;

    void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(this.gameObject);


        }
   
        else if (Instance != this) 
        {
            Destroy(this.gameObject);


        }
    
    
    }

 







}
