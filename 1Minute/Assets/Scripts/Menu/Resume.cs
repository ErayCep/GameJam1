using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Resume : MonoBehaviour
{
    public void playGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(1);
        }
        
    }
    void Update()
    {
    playGame();
    }
}
