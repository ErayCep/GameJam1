using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinAnim : MonoBehaviour  
{
    public TextMeshProUGUI coinstext;
    void Update()
    {
        coinstext.text = RealMoney.Instance.realGold.ToString();
    }
}
