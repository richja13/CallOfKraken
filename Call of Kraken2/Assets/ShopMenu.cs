using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopMenu : MonoBehaviour
{
    public int Money;
    public int Tea;
    public int Rum;
    public int sugar;
    public Text MoneyText;
    public Text TeaText;
    public Text RumText;
    public Text SugarText;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Money = PlayerStatsScript.Money;

        Tea = PlayerStatsScript.Tea;
        
       // MoneyText.text = Money + "Gold";

       // TeaText.text = Tea + "Tea";
    }
    
    
    
}


























