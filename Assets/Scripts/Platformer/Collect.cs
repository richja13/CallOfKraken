using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public Text text;
    public Text TimerText;
    public Text RumText;
    public GameObject BlowingKeg;
    public int Kegs = 0;
    private float Timer = 1800f;
    private bool TimerStart = false;
    public bool HaveGoldenKey = false;
    public GameObject door;
    public static int RumBarells = 0;
    public int TeaCrate;
    public Text TeaText;
    public Text Gold;
    public static int MoneyCounter;
    public static int MoneyAdd;
    public int GoldCounter;
    public int TeaCounter;
    public ParticleSystem GoldenShower;
    public int BuyTeaValue;
    public int SellTeaValue;
    public Text SellTeaText;
    public Text BuyTeaText;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
       TeaCrate = PlayerStatsScript.Tea;
       MoneyCounter = PlayerStatsScript.Money;

        GoldCounter = MoneyCounter;
        
        if (MoneyCounter > MoneyAdd)
        {
            MoneyAdd++;
        }

        //Gold.text = MoneyAdd + " gold";
        
        //TeaText.text = TeaCrate + " Tea";
        
     /*   if (TimerStart == true)
        {
            Timer -= 1f;
            //TimerText.text = Timer/30 + " Seconds";
        }
        if (Timer == 0f)
        {
            
        }
       */ 
        //RumText.text = "Rum " + RumBarells;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GoldenCrate")
        {
            Instantiate(GoldenShower, collision.transform.position,transform.rotation);
            MoneyCounter += 120;
            Destroy(collision.gameObject);   
        }

        if (collision.gameObject.tag == "TeaCrate")
        {
            Destroy(collision.gameObject);   
            //TeaCrate++;
        }

        
        
        if (collision.gameObject.tag == "Island")
        {
            BuyTeaValue = collision.gameObject.GetComponent<IslandScript>().BuyTea;
            SellTeaValue = collision.gameObject.GetComponent<IslandScript>().SellTea;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "ExplosionPlace" && Kegs == 5 && Timer != 0f)
        {
            Destroy(text);
            Destroy(TimerText);
            TimerStart = false;
            Instantiate(BlowingKeg);
        }

        if (collision.gameObject.tag == "Keg")
        {
            Kegs += 1;
            text.text = "Kegs " + Kegs + "/5";
        }
        if (collision.gameObject.tag == "GoldenKey")
        {
            HaveGoldenKey = true;
        }
    }
}
