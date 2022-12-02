using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ShopSceneScript : MonoBehaviour
{
    public int LoadSceneQueue;
    
    public GameObject ShopScene;
  
    void Update()
    {
       
        if(PlayerMovement.instance.isOnMarket == true)
        {
          ShopScene.SetActive(true);
            if (Input.GetKeyDown(KeyCode.M) )
            {
                SceneManager.LoadScene(LoadSceneQueue);

            }
        }

        if (PlayerMovement.instance.isOnMarket == false)
        {
            ShopScene.SetActive(false);
            
        }

    }
}
