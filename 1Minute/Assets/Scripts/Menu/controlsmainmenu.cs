using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsmainmenu : MonoBehaviour
{
    public void controlsbackmain()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            SceneManager.LoadScene(0);

        }
    }
    void Update()
    {
        controlsbackmain();
    }
}
