using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour
{
    public void acontrolscreen()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {

            SceneManager.LoadScene(0);
        }
    }
}
