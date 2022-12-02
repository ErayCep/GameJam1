using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controls : MonoBehaviour
{
    public void controlsback()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(3);
        }
        //else if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    SceneManager.LoadScene(4);
        //}
    }
    void Update()
    {
        controlsback();   
    }
}
