using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMoney : MonoBehaviour
{
        
    public float realGold ;

    public bool ballBombUnlockedload;

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
