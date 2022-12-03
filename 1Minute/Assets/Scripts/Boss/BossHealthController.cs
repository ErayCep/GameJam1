using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{
    public static BossHealthController instance;
    public Slider healthSlider;

    public GameObject endDoor;

    public int currentHealth = 30;

    public BossBattle boss;

    public GameObject AudioEnd;
    public GameObject AudioStart;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        healthSlider.maxValue = currentHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if(currentHealth <= 0)
        {
            currentHealth = 0;

            boss.EndBattle();
            endDoor.SetActive(false);
            AudioEnd.SetActive(false);
            AudioStart.SetActive(true);
           
        }

        healthSlider.value = currentHealth;
    }
}

