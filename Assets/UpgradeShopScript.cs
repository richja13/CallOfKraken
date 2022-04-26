using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UpgradeShopScript : MonoBehaviour
{
    public RectTransform UpgradeButton;
    public RectTransform UpgradeMenu;
    private float i;
    private Vector2 UpgradeButtonStartPosition;
     private Vector2 UpgradeMenuStartPosition;
    private bool UpgradeMenuOpen;
    public Text PlayerAttackText;
    public Text PlayerStaminaText;
    public Text PlayerHpText;
    public Text BoatCrewText;
    public Text BoatCannonsText;
    public Text BoatHpText;
    int PlayerDamage;
    float PlayerStamina;
    int PlayerHP;
    int BoatHp;
    float BoatCrew;
    int BoatCannons;
    int PlayerHpPrice = 60;
    int PlayerStaminaPrice = 40;
    int PlayerDamagePrice = 55;
    int BoatHpPrice = 190;
    int BoatCannonsPrice = 120;
    int BoatCrewPrice = 40;
    float NewPlayerDamage;
    float NewPlayerStamina;
    float NewPlayerHp;
    float NewBoatHp;
    float NewBoatCannons;
    float NewBoatCrew;
    public RectTransform Dialog;
    public Text moneyText;
    public Text PlayerDamagePriceText;
    public Text PlayerStaminaPriceText; 
    public Text PlayerHpPriceText;
    public Text BoatHpPriceText;
    public Text BoatCrewPriceText;
    public Text BoatCannonsPriceText;
    int Money;
    public bool ShopHelp;
    public Text BoatHpLvl;
    public Text BoatAttackLvl;
    public Text PlayerAttackLvl;
    public Text PlayerStaminaLvl;
    public Text PlayerHpLvl;

    int BoatAttackNumber;
    int BoatHpNumber;
    int PlayerHpNumber;
    int PlayerAttackNumber;
    int PlayerStaminaNumber;

    // Start is called before the first frame update
    void Start()
    {
        UpgradeButtonStartPosition = UpgradeButton.anchoredPosition;
        UpgradeMenuStartPosition = UpgradeMenu.anchoredPosition;
        ShopHelp = false;
    }

    // Update is called once per frame
    void Update()
    {
        Money = PlayerStatsScript.Money;
        PlayerDamage = PlayerStatsScript.AttackDmg;
        PlayerStamina = PlayerStatsScript.GunDamage;
        PlayerHP = PlayerStatsScript.Hp;
        BoatHp = PlayerStatsScript.BoatHp;
        BoatCannons = PlayerStatsScript.BoatAttack;
        BoatCrew = PlayerStatsScript.BoatCrew;

        NewPlayerDamage = PlayerDamage + 3;
        NewPlayerHp = PlayerHP + 10;
        NewPlayerStamina = PlayerStamina + 2;
        NewBoatHp = BoatHp + 50;
        NewBoatCrew = BoatCrew + 1;
        NewBoatCannons = BoatCannons + 0.2f;

        moneyText.text = "$" + Money;

       // PlayerDamagePriceText.text = "$" + PlayerDamagePrice;
       // PlayerStaminaPriceText.text = "$" + PlayerStaminaPrice;
       // PlayerHpPriceText.text = "$" + PlayerHpPrice;

        PlayerHpLvl.text = PlayerHpNumber  + "";
        PlayerAttackLvl.text = PlayerAttackNumber + "";
        PlayerStaminaLvl.text = PlayerStaminaNumber + "";

        BoatHpLvl.text = BoatHpNumber + "";
        BoatAttackLvl.text = BoatAttackNumber + "";
        

        if(!ShopHelp)
        {
            PlayerAttackText.text = "$" + PlayerDamagePrice + "\n" + "Damage+  " + PlayerDamage + "->" + NewPlayerDamage;
            PlayerStaminaText.text = "$" + PlayerStaminaPrice + "\n" + "Flintlock+  " + PlayerStamina * 10 + "->" + NewPlayerStamina * 10;
            PlayerHpText.text = "$" + PlayerHpPrice + "\n" + "HP+ " + PlayerHP + "->" + NewPlayerHp;
            BoatCannonsText.text =  "$" + BoatCannonsPrice + "\n" + "Cannons+ " + BoatCannons + "->" + NewBoatCannons;
            BoatHpText.text =  "$" + BoatHpPrice + "\n" + "Hp+ " + BoatHp + "->" + NewBoatHp;
            BoatCrewText.text = "$" + BoatCrewPrice + "\n" +  "Crew+ " + BoatCrew + "->" + NewBoatCrew;
        }
        else
        {
            PlayerAttackText.text = "Sharpen your sword";
            PlayerStaminaText.text = "Upgrades your pistol damage";
            PlayerHpText.text = "Gives you more health";
            BoatCannonsText.text =  "Upgrades your cannons damage";
            BoatHpText.text =  "Gives you more ship armor";
            BoatCrewText.text = "Add one more man to your crew";
        }

       // BoatHpPriceText.text = "$" + BoatHpPrice;
       // BoatCrewPriceText.text = "$" + BoatCrewPrice;
       // BoatCannonsPriceText.text = "$" + BoatCannonsPrice; 

        if(UpgradeMenuOpen == true)
        {
            UpgradeMenu.anchoredPosition = new Vector2(0,0);
            //Dialog.anchoredPosition = new Vector2(0,160);
        }
        else
        {
            //Dialog.anchoredPosition = new Vector2(0,2400);
            UpgradeMenu.anchoredPosition = UpgradeMenuStartPosition;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(UpgradeButton.anchoredPosition.y < 100)
            {
                i++;
                UpgradeButton.anchoredPosition = new Vector2(0,i);
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player")
        {
          i = 0;
          UpgradeButton.anchoredPosition = UpgradeButtonStartPosition;
          UpgradeMenuOpen = false;
        }
    }

    public void OpenShop()
    {
        if(UpgradeMenuOpen)
        {
            Time.timeScale = 0.1f;
            UpgradeMenuOpen = false;
        }
        else
        {
            Time.timeScale = 1f;
            UpgradeMenuOpen = true;
        }
    }

    public void AddPlayerDamage()
    {
        if(Money >= PlayerDamagePrice)
        {
            PlayerAttackNumber += 1;
            PlayerStatsScript.Money -= PlayerDamagePrice;
            PlayerDamagePrice = Mathf.FloorToInt(PlayerDamagePrice * 1.4f);
            Debug.Log(PlayerStatsScript.AttackDmg);
            PlayerDamage += 3;
            PlayerStatsScript.AttackDmg = PlayerDamage;
        }
    }

    public void AddPlayerStamina()
    {
        if(Money >= PlayerStaminaPrice)
        { 
            PlayerStaminaNumber += 1;
            PlayerStatsScript.Money -= PlayerStaminaPrice;
            PlayerStaminaPrice = Mathf.FloorToInt(PlayerStaminaPrice * 1.4f);
            PlayerStatsScript.GunDamage += 0.2f;
            
        }
    }

    public void AddPlayerHp()
    {
        if(Money >= PlayerHpPrice)
        {
            PlayerHpNumber += 1;
            PlayerStatsScript.Money -= PlayerHpPrice;
            PlayerHpPrice = Mathf.FloorToInt(PlayerHpPrice * 1.4f);
            PlayerHP += 10;
            PlayerStatsScript.Hp = PlayerHP;
        }
    }

    public void AddBoatHp()
    {
        if(Money >= BoatHpPrice)
        {
            BoatHpNumber += 1;
            PlayerStatsScript.Money -= BoatHpPrice;
            BoatHpPrice = Mathf.FloorToInt(BoatHpPrice * 1.4f);
            BoatHp += 50;
            PlayerStatsScript.BoatHp = BoatHp;
        }
    }

    public void AddBoatCannons()
    {
        if(Money >= BoatCannonsPrice)
        {
            BoatAttackNumber += 1;
            PlayerStatsScript.Money -= BoatCannonsPrice;
            BoatCannonsPrice = Mathf.FloorToInt(BoatCannonsPrice * 1.4f);
            BoatCannons += 2;
            PlayerStatsScript.BoatAttack = BoatCannons;
        }
    }

    public void AddBoatCrew()
    {
        if(Money >= BoatCrewPrice)
        {
            PlayerStatsScript.Money -= BoatCrewPrice; 
            BoatCrew += 1;
            PlayerStatsScript.BoatCrew = BoatCrew;
        }
    }

    public void ClosePanel()
    {
        UpgradeMenuOpen = false;
    }

    public void Help()
    {
        if(ShopHelp == false)
        {
            ShopHelp = true;
        }
        else
        {
            ShopHelp = false;
        }
    }

}
