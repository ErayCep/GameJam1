using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsToMainGame : MonoBehaviour
{
    public void controlstogame()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            SceneManager.LoadScene(0);

        }
    }
    void Update()
    {
        controlstogame();
    }
}