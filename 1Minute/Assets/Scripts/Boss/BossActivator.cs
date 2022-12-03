using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject bossToActivate;
    public GameObject AudioStart1;
    public GameObject AudioEnd1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            bossToActivate.SetActive(true);

            gameObject.SetActive(false);
            AudioEnd1.SetActive(false);
            AudioStart1.SetActive(true);
        }
    }
}