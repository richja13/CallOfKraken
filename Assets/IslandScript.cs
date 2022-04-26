using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandScript : MonoBehaviour
{
    public int SellTea;
    public int BuyTea;
    public int BuyRum;
    public int SellRum;
    public int BuySugar;
    public int SellSugar;
    public Text SellTeaText;
    public Text BuyTeaText;
    public RectTransform IslandButton;    
    void Start()
    {
        SellTea = Random.Range(35, 60);
        BuyTea = SellTea + Random.Range(5,15);

        SellSugar = Random.Range(35, 60);
        BuySugar = SellSugar + Random.Range(5, 15);

        SellRum = Random.Range(35,60);
        BuyRum = SellRum + Random.Range(5, 15);
    }
   
    void Update()
    {
        //SellTeaText.text = SellTea + "$";
        //BuyTeaText.text = BuyTea + "$";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Vector2.Distance(transform.position, collision.gameObject.transform.position) < 200f)
        {
            IslandButton.anchoredPosition = new Vector2(193,31);
        }

      
    }

    

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IslandButton.anchoredPosition = new Vector2(287, -300);
        }
    }

}
