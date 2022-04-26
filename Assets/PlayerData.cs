using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public GameObject Player;
    public int gold;
    public int Tea;
    public int Sugar;
    public int Rum;
    public Text GoldText;

    public Text TeaPriceText;
    public Text SellPriceText;
    public Text BuyPriceText;
    int IslandTeaPriceSell;
    int IslandTeaPriceBuy;

    public Text SugarPriceText;
    public Text SellSugarText;
    public Text BuySugarText;

    int IslandSugarSellPrice;
    int IslandSugarBuyPrice;

    public Text RumPriceText;
    public Text RumSellText;
    public Text RumBuyText;
    int IslandRumSellPrice;
    int IslandRumBuyPrice;

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Tea = PlayerStatsScript.Tea;
        gold = PlayerStatsScript.Money; 
        Sugar = PlayerStatsScript.Sugar;
        Rum = PlayerStatsScript.Rum;


        GoldText.text = "$" + PlayerStatsScript.Money;

        TeaPriceText.text =  "+" + Tea;      
        BuyPriceText.text = "$" + IslandTeaPriceBuy;
        SellPriceText.text = "$" + IslandTeaPriceSell;

        SugarPriceText.text = "+" + Sugar;
        BuySugarText.text = "$" + IslandSugarBuyPrice;
        SellSugarText.text = "$" + IslandSugarSellPrice;

        RumPriceText.text = "+" + Rum;
        RumBuyText.text = "$" + IslandRumBuyPrice;
        RumSellText.text = "$" + IslandRumSellPrice; 

 
              
        //IslandTeaPriceBuy = Player.GetComponent<PlayerMovement>().
    }

    public void BuyTea()
    {
        if(gold >= IslandTeaPriceBuy)
        {
            PlayerStatsScript.Tea++;
            PlayerStatsScript.Money -= IslandTeaPriceBuy;             
        }
    }

    public void SellTea()
    {
        if(Tea > 0)
        {
            PlayerStatsScript.Money += IslandTeaPriceSell;
            PlayerStatsScript.Tea -= 1;
        }
    }

    public void SellSugar()
    {
        if(Sugar > 0)
        {
            PlayerStatsScript.Money += IslandSugarSellPrice;
            PlayerStatsScript.Sugar--;
        }
    }

    public void BuySugar()
    {
        if(gold >= IslandSugarBuyPrice)
        {
            PlayerStatsScript.Sugar++;
            PlayerStatsScript.Money -= IslandSugarBuyPrice;
        }
    }

    public void BuyRum()
    {
        if(gold >= IslandRumBuyPrice)
        {
            PlayerStatsScript.Rum++;
            PlayerStatsScript.Money -= IslandRumBuyPrice;
        }
    }

    public void SellRum()
    {
        if(Rum > 0)
        {
            PlayerStatsScript.Money += IslandRumSellPrice;
            PlayerStatsScript.Rum--;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Island")
        {
            IslandTeaPriceBuy = collision.gameObject.GetComponent<IslandScript>().BuyTea;
            IslandTeaPriceSell = collision.gameObject.GetComponent<IslandScript>().SellTea;
            IslandRumBuyPrice = collision.gameObject.GetComponent<IslandScript>().BuyRum;
            IslandRumSellPrice = collision.gameObject.GetComponent<IslandScript>().SellRum;
            IslandSugarBuyPrice = collision.gameObject.GetComponent<IslandScript>().BuySugar;
            IslandSugarSellPrice = collision.gameObject.GetComponent<IslandScript>().SellSugar;
        }
    }

}
