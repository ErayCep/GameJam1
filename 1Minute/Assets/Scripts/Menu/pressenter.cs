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
        if (Input.GetKeyDown(KeyCode.U))
        {
            Quit();
        }
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

    public void controlscreen()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
