using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuisnessScript : MonoBehaviour
{
    public Slider Money;
    public Slider Tea;
    public Slider Sugar;
    public Slider Rum;
    public Button MoneyUpgrade;
    public Button MagazineUpgrade;
    public Button TeaUpgrade;
    public Button SugarUpgrade;
    public Button RumUpgrade;
    public Button CollectAllButton;
    public Text MagazineText;
    public Text MoneyText;
    public Text TeaText;
    public Text SugarText;
    public Text RumText;
    public Text AddMagazineText;
    public Text AddMoneyText;
    public Text AddTeaText;
    public Text AddSugarText;
    public Text AddRumText;
    public Text CostMagazineText;
    public Text CostMoneyText;
    public Text CostTeaText;
    public Text CostSugarText;
    public Text CostRumText;
    public Text AllMoney;
    float SpeedMoney = 0.5f;
    float SpeedTea = 0.01f;
    float SpeedSugar = 0.03f;
    float SpeedRum = 0.05f;

    public int TotalMoney;
    public int TotalTea;
    public int TotalSugar;
    public int TotalRum;
    public int TotalMagazine = 100;

    float MoneyPerTime;
    float TeaPerTime;
    float SugarPerTime;
    float RumPerTime;
    bool NoSpace;

    static int MoneyCostUpgrade = 40;
    static int RumCostUpgrade = 50;
    static int SugarCostUpgrade = 60;
    static int TeaCostUpgrade = 30;
    static int MagazineCostUpgrade = 90;

    public AudioSource CollectSfx;
    public AudioSource UpgradeSfx;

    public RectTransform PanelPosition;
    bool PanelOpen;
    static int IslandOwner = 0; 
    public GameObject BuyIslandPanel;
    public GameObject BuyIslandButton;
    public int IslandPrice;

    // Start is called before the first frame update
    void Start()
    {
        IslandOwner = PlayerPrefs.GetInt("IslandOwner");

        if(IslandOwner == 0)
        {
            MagazineCostUpgrade = 90;
            TeaCostUpgrade = 60;
            SugarCostUpgrade = 90;
            RumCostUpgrade = 100;
            MoneyCostUpgrade = 80;

            SpeedMoney = 0.5f;
            SpeedTea = 0.01f;
            SpeedSugar = 0.03f;
            SpeedRum = 0.05f;
        }
        else
        {
        
        MoneyCostUpgrade = PlayerPrefs.GetInt("MoneyUpgrade");
        TeaCostUpgrade = PlayerPrefs.GetInt("TeaUpgrade");
        SugarCostUpgrade = PlayerPrefs.GetInt("SugarUpgrade");
        MagazineCostUpgrade = PlayerPrefs.GetInt("");
        
        SpeedMoney = PlayerPrefs.GetFloat("MoneySpeed");
        SpeedTea = PlayerPrefs.GetFloat("TeaSpeed");
        SpeedSugar = PlayerPrefs.GetFloat("SugarSpeed");
        SpeedRum = PlayerPrefs.GetFloat("RumSpeed");

        TotalMoney = PlayerPrefs.GetInt("TotalMoney");
        TotalTea = PlayerPrefs.GetInt("TotalTea");
        TotalSugar = PlayerPrefs.GetInt("TotalSugar");
        TotalMagazine = PlayerPrefs.GetInt("TotalMagazine");
        TotalRum = PlayerPrefs.GetInt("TotalRum");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("IslandOwner", IslandOwner);

        PlayerPrefs.SetInt("MoneyUpgrade",MoneyCostUpgrade);
        PlayerPrefs.SetInt("TeaUpgrade",TeaCostUpgrade);
        PlayerPrefs.SetInt("SugarUpgrade",SugarCostUpgrade);
        PlayerPrefs.SetInt("RumUpgrade",RumCostUpgrade);
        PlayerPrefs.SetInt("MagazineUpgrade",MagazineCostUpgrade);

        PlayerPrefs.SetInt("TotalMoney",TotalMoney);
        PlayerPrefs.SetInt("TotalTea",TotalTea);
        PlayerPrefs.SetInt("TotalSugar",TotalSugar);
        PlayerPrefs.SetInt("TotalRum",TotalRum);

        PlayerPrefs.SetFloat("MoneySpeed", SpeedMoney);
        PlayerPrefs.SetFloat("TeaSpeed", SpeedTea);
        PlayerPrefs.SetFloat("RumSpeed", SpeedRum);
        PlayerPrefs.SetFloat("SugarSpeed", SpeedSugar);

        AllMoney.text = "$" + PlayerStatsScript.Money;

        if(IslandOwner == 1)
        {
            CostMoneyText.text = "$" + MoneyCostUpgrade;
            CostSugarText.text = "$" + SugarCostUpgrade;
            CostTeaText.text = "$" + TeaCostUpgrade;
            CostRumText.text = "$" + RumCostUpgrade;
            CostMagazineText.text = "$" + MagazineCostUpgrade;

            //MoneyUpgrade.onClick.AddListener(UpgradeMoney);
            //MagazineUpgrade.onClick.AddListener(UpgradeMagazine);
            //TeaUpgrade.onClick.AddListener(UpgradeTea);
            //SugarUpgrade.onClick.AddListener(UpgradeSugar);
            //RumUpgrade.onClick.AddListener(UpgradeRum);

            MagazineFunction();
            GetMoney();
            GetTea();
            GetSugar();
            GetRum();
            BuyIslandButton.SetActive(false);
            BuyIslandPanel.SetActive(false);

            CostMoneyText.enabled = true;
            CostSugarText.enabled = true;
            CostTeaText.enabled = true;
            CostRumText.enabled = true;
            CostMagazineText.enabled = true;
            AddMoneyText.enabled = true;
            AddSugarText.enabled = true;
            AddTeaText.enabled = true;
            AddRumText.enabled = true;
            Money.enabled = true;
            Tea.enabled = true;
        }
        else
        {
            CostMoneyText.enabled = false;
            CostSugarText.enabled = false;
            CostTeaText.enabled = false;
            CostRumText.enabled = false;
            CostMagazineText.enabled = false;
            AddMoneyText.enabled = false;
            AddSugarText.enabled = false;
            AddTeaText.enabled = false;
            AddRumText.enabled = false;
            Money.enabled = false;
            Tea.enabled = false;
        }

        if(PanelOpen)
        {
            PanelPosition.anchoredPosition = new Vector2(0,0);
        }
        else
        {
            PanelPosition.anchoredPosition = new Vector2(3000,3000);
        }
    }


    void MagazineFunction()
    {
        var MagazineNow = TotalRum + TotalSugar + TotalTea;

        MagazineText.text = MagazineNow + "/" + TotalMagazine;

        if(TotalRum + TotalSugar + TotalTea >= TotalMagazine)
        {
            NoSpace = true;
        }
        else
        {
            NoSpace = false;
        }
    }

    void GetMoney()
    {
        MoneyText.text = "$" + TotalMoney;
        MoneyPerTime = (SpeedMoney*35)/Money.maxValue;

        MoneyPerTime = MoneyPerTime*10;
        MoneyPerTime = Mathf.RoundToInt(MoneyPerTime);
        MoneyPerTime = MoneyPerTime/10;

        AddMoneyText.text = MoneyPerTime+"/sec";

        if(Money.value < Money.maxValue)
        {
            Money.value += SpeedMoney;
        }
        else if(Money.value >= Money.maxValue)
        {
            TotalMoney += 1;
            Money.value = 0;
        }
        
    }

    void GetTea()
    {
        TeaText.text = "+" + TotalTea;
        TeaPerTime = (SpeedTea*35)*60/Tea.maxValue;

        TeaPerTime = TeaPerTime*10;
        TeaPerTime = Mathf.RoundToInt(TeaPerTime);
        TeaPerTime = TeaPerTime/10;

        AddTeaText.text = TeaPerTime+"/min";

        if(!NoSpace)
        {
            if(Tea.value < Tea.maxValue)
            {
                Tea.value += SpeedTea;
            }
            else if(Tea.value >= Tea.maxValue)
            {
                TotalTea += 1;
                Tea.value = 0;
            }
        }
    }

    void GetSugar()
    {
        SugarText.text = "+" + TotalSugar;
        SugarPerTime = (SpeedSugar*35)*60/Sugar.maxValue;   
        SugarPerTime = SugarPerTime*10;
        SugarPerTime = Mathf.RoundToInt(SugarPerTime);
        SugarPerTime = SugarPerTime/10;

        AddSugarText.text = SugarPerTime + "/min";

        if(!NoSpace)
        {
            if(Sugar.value < Sugar.maxValue)
            {
                Sugar.value += SpeedSugar;
            }
            else if(Sugar.value >= Sugar.maxValue)
            {
                TotalSugar += 1;
                Sugar.value = 0;
            }
        }
    }

    void GetRum()
    {
        RumText.text = "+" + TotalRum;
        RumPerTime = (SpeedRum*35)*60/Rum.maxValue;
        RumPerTime = RumPerTime*10;
        RumPerTime = Mathf.RoundToInt(RumPerTime);
        RumPerTime = RumPerTime/10;

        AddRumText.text = RumPerTime + "/min";

        if(!NoSpace)
        {
            if(Rum.value < Rum.maxValue)
            {
                Rum.value += SpeedRum;
            }
            else if(Rum.value >= Rum.maxValue)
            {
                TotalRum += 1;
                Rum.value = 0;
            } 
        }
    }

    public void UpgradeMoney()
    {
        if(PlayerStatsScript.Money >= MoneyCostUpgrade)
        {
            PlayerStatsScript.Money -= MoneyCostUpgrade;
            SpeedMoney += SpeedMoney * 0.15f;
            MoneyCostUpgrade += Mathf.FloorToInt(MoneyCostUpgrade * 0.2f);
            UpgradeSfx.Play(1);
        }
    }

    public void UpgradeTea()
    {
        if(PlayerStatsScript.Money >= TeaCostUpgrade)
        {
            PlayerStatsScript.Money -= TeaCostUpgrade;
            SpeedTea += SpeedTea * 0.12f;
            TeaCostUpgrade += Mathf.FloorToInt(TeaCostUpgrade * 0.2f);
            UpgradeSfx.Play(1);
        }
    }

    public void UpgradeSugar()
    {
        if(PlayerStatsScript.Money >= SugarCostUpgrade)
        {
            PlayerStatsScript.Money -= SugarCostUpgrade;
            SpeedSugar += SpeedSugar * 0.13f;
            SugarCostUpgrade += Mathf.FloorToInt(SugarCostUpgrade * 0.2f);
            UpgradeSfx.Play(1);
        }
    }

    public void UpgradeRum()
    {
        if(PlayerStatsScript.Money >= RumCostUpgrade)
        {
            PlayerStatsScript.Money -= RumCostUpgrade;
            SpeedRum += SpeedRum * 0.14f;
            RumCostUpgrade += Mathf.FloorToInt(RumCostUpgrade * .2f);
            UpgradeSfx.Play(1);
        }
    }

    public void UpgradeMagazine()
    {
        if(PlayerStatsScript.Money >= MagazineCostUpgrade)
        {
            PlayerStatsScript.Money -= MagazineCostUpgrade;
            TotalMagazine += 100;
            MagazineCostUpgrade += Mathf.FloorToInt(MagazineCostUpgrade * .4f);
            UpgradeSfx.Play(1);
        }
    }

    public void CollectMoney()
    {
        PlayerStatsScript.Money += TotalMoney;
        TotalMoney = 0;
        CollectSfx.Play(1);
    }

    public void CollectTea()
    {
        PlayerStatsScript.Tea += TotalTea;
        TotalTea = 0;
        CollectSfx.Play(1);
    }

    public void CollectSugar()
    {
        PlayerStatsScript.Sugar += TotalSugar;
        TotalSugar = 0;
        CollectSfx.Play(1);
    }

    public void CollecRum()
    {
        PlayerStatsScript.Rum += TotalRum;
        TotalRum = 0;
        CollectSfx.Play(1);
    }

    public void ClosePanelMenu()
    {
        if(PanelOpen)
        {
            PanelOpen = false;
        }        
        else
        {
            PanelOpen = true;
        }
    }

    public void BuyIsland()
    {
        if(IslandOwner == 0)
        {
            if(PlayerStatsScript.Money >= IslandPrice)
            {
                PlayerStatsScript.Money -= IslandPrice;
                IslandOwner = 1;
            }
        }
    }
}
