using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressenter : MonoBehaviour
{
    /* public void Update()
     {

         playGameStart();


     }
     public void playGameStart()
     {
         if (Input.GetKeyDown(KeyCode.Return))
         {
             SceneManager.LoadScene(1);
         }
     }*/
    public void Update()
    {
  
        playGameStart();
        //pausegame();

    }

    public void playGameStart()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }


}
