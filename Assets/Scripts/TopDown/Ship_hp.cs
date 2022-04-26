using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship_hp : MonoBehaviour
{
    
    public Image Hp1;
    public Slider HpRecoverySlider;
    public float Health;
    public float OldHealth;
    public bool HealthDamage;
    public float Timer;
    public bool TimerTrue;
    public CamShake CamShake;
    
    public Transform Magnes;
    public ParticleSystem CanvasParticle;
    public GameObject MoneyText;
    public RectTransform ads;
    public bool OpenAd;
    public bool Tutorial;
    public GameObject ShopButton;
    public GameObject ShipsSpawner;

    // Start is called before the first frame update
    void Start()
    {
        Health = PlayerStatsScript.BoatHp;
        if(Tutorial)
        {
            Health = Health/1.05f;
        }
    }

        // Update is called once per frame
    void Update()
    {
        if( ProjectMaster.IActMissionNumber >= 0 && ProjectMaster.IActMissionNumber <= 2)
        {
          //  ShipsSpawner.SetActive(false);
        }
        else
        {
          //  ShipsSpawner.SetActive(true);
        }


       if(Health <= PlayerStatsScript.BoatHp/2.4f && Tutorial == true)
       {
            Health += 1f;
       }

        if(Input.GetKey(KeyCode.X))
        {
            Health -= 10;
        }
            

        if (Health <= 0)
        {
            //SceneManager.LoadScene("topdown");
            //Destroy(this.gameObject);
        }

        if(OpenAd)
        {
            ads.anchoredPosition = new Vector2(0,0);
        }
        else
        {
            ads.anchoredPosition = new Vector2(3000, 3000);
        }

        var BHp = ((Health*186)/PlayerStatsScript.BoatHp);
        
        Hp1.rectTransform.sizeDelta = new Vector2(BHp,Hp1.rectTransform.sizeDelta.y);

        if(Health >= PlayerStatsScript.BoatHp)
        {
            HealthDamage = false;
        }
        else
        {
            
            HealthDamage = true;   
        }

        if(HealthDamage)
        {
            Invoke("RepairShip",2.1f);
            Health -= 0.45f * ((PlayerStatsScript.BoatHp - Health)/300);
        }
              
    }
    void RepairShip()
    {
        Health += 1*(HpRecoverySlider.value/50);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
   

        if (collision.gameObject.tag == "EnemyCannonBall")
        {
            Health -= 15;
            Timer = 0;   
            //CamShake.Shake(0.25f, 0.3f);            
             CamShake.Shake(0.3f, 0.8f);  
            collision.GetComponent<CircleCollider2D>().enabled = false;
            collision.GetComponent<SpriteRenderer>().color = Color.clear;
        }

        if(collision.gameObject.tag == "Coin")
        {
            PlayerStatsScript.Money += 350;
            Destroy(collision.gameObject);
            Instantiate(CanvasParticle, collision.transform.position, collision.transform.rotation);
            Instantiate(MoneyText, collision.transform.position, collision.transform.rotation);
        }
        
        if(collision.gameObject.tag == "BoxAds")
        {
            Destroy(collision.gameObject);
            Instantiate(CanvasParticle, collision.transform.position, collision.transform.rotation);
            OpenAd = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            ShopButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-258, -137f);
        }

        if(collision.gameObject.name == "Mikel")
        {
            ShipsSpawnerScript.FleetNumber = 1;
        }

        if(collision.gameObject.name == "Amelia")
        {
            ShipsSpawnerScript.FleetNumber = 2;
        }

        if(collision.gameObject.name == "Maynard")
        {
            ShipsSpawnerScript.FleetNumber = 3;
        }

        if(collision.gameObject.name == "Aleksander")
        {
            ShipsSpawnerScript.FleetNumber = 4;
        }

    }

    public void CloseAdPanel()
    {
        if(OpenAd == true)
        {
            OpenAd = false;
        }
    }
}
