using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlback : MonoBehaviour
{
    public void controlsback()
    {
        if((Input.GetKeyDown(KeyCode.Escape)))
        {
                SceneManager.LoadScene(2);
     
        }
    }
     void Update()
    {
        controlsback();    
    }
}