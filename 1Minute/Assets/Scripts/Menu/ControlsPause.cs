using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsPause : MonoBehaviour
{
 public void controlpause()
    {
        if ((Input.GetKeyDown(KeyCode.C)))
        {

            SceneManager.LoadScene(2);
        }

    }
     void Update()
    {
        controlpause(); 
    }
}
