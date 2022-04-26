using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    static public int TutorialStages = 1;
    public RectTransform Arrow;
    public Vector2 ArrowPosition;
    public RectTransform TextPosition;
    public Text TutorialText;
    bool CanChange;
    int PreviousStage;
    public Button BoardButton1;
    public Button BoardButton2;

    public Shooting szut;
    public RectTransform Sliders;
    public SceneTransitionAnimationScript transition;
    public GameObject Player;
    public GameObject transitionObject;
    public Ship_hp PlayerHp;
    public GameObject Enemy;
    bool a;

    public GameObject SailSlider;
    public GameObject HpSlider;
    public GameObject FireModeButton;
    public GameObject MapButton;
    public GameObject CannonsSlider;
    public GameObject ShipDamagedTable;
    public GameObject ShipRotateTable;
    public GameObject ShipCannonsTable;
    void Start()
    {
        CanChange = true;
        a = true;
        SailSlider.SetActive(false);
        HpSlider.SetActive(false);
        FireModeButton.SetActive(false);
        MapButton.SetActive(false);
        CannonsSlider.SetActive(false);
        ShipRotateTable.SetActive(true);
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Enemy == null && TutorialStages == 6)
      {
            TutorialStages = 7;
      }
       

       if(TutorialStages >= 9)
       {
           //BoardButton1.onClick.AddListener();
           //BoardButton2.onClick.AddListener();
       }

        if(TutorialStages == 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(CanChange)
                {
                    CanChange = false;
                    PreviousStage = TutorialStages;
                    Invoke("FirstStage", 2f);
                }
            }
        }       

      

        switch(TutorialStages)
        {
            case 0:
                Time.timeScale = 1;
                Arrow.anchoredPosition = new Vector2(-3000f,-3000f);
                TextPosition.anchoredPosition = new Vector2(-3000f,-3000f);
               
            break;

            case 1:
                Time.timeScale = 0.5f;
                Arrow.anchoredPosition = new Vector2(-3000,-3000);
                TextPosition.anchoredPosition = new Vector2(0,0);
                TutorialText.text  = "Touch screen then move joystick to rotate your ship";
                
            break;
            
            case 2:
                Time.timeScale = 0.5f;
                Arrow.anchoredPosition = new Vector2(-135.3f,-81f);
                TextPosition.anchoredPosition = new Vector2(-133.3f, 104f);
                TutorialText.text  = "Add More Crew to increse SailSpeed";
                SailSlider.SetActive(true);
            break;

            case 3:
         Time.timeScale = 0.5f;
                Arrow.anchoredPosition = new Vector2(362, -52);
               TextPosition.anchoredPosition = new Vector2(164,-13);
               TutorialText.text  = "Click Button to enter the Combat Mode";
               FireModeButton.SetActive(true);
               Enemy.SetActive(true);
            break;

            case 4:
                Time.timeScale = 0.5f;
                Arrow.anchoredPosition = new Vector2(-3000,-3000);
                TextPosition.anchoredPosition = new Vector2(0,0);
                TutorialText.text  = "Click Left or Right shooting button to Fire the Cannons and sink the Enemy Ship";
            break;

            case 5:
            Time.timeScale = 0.5f;

             Arrow.anchoredPosition = new Vector2(-247f,-200f);
                Arrow.eulerAngles = new Vector3(0,0,90);
               TextPosition.anchoredPosition = new Vector2(0,0);
               
               TutorialText.text  = "Add more Crew to reload cannons faster";
               CannonsSlider.SetActive(true);
               ShipCannonsTable.SetActive(true);

            if(szut.Shooting_mode == false)
            {
                //Arrow.anchoredPosition = new Vector2(-247,-151.9f); 
                Sliders.anchoredPosition = new Vector2(0,129);
                szut.Shooting_mode = true;
            }

               
            break;  

            case 6:
            /*
                Time.timeScale = 0.5f;
                TextPosition.anchoredPosition = new Vector2(0,0);
                TutorialText.text  = "Sunk pirate ship to move on";
                */

                TutorialStages = 7;
            break;
            

            case 7:
             Time.timeScale = 0.5f;
            if(szut.Shooting_mode == false)
            {
                Arrow.anchoredPosition = new Vector2(-247,-200);
                
            }
            else
            {
                Arrow.anchoredPosition = new Vector2(-247,-151.9f); 
            }
             //Arrow.rotation = new Quaternion(0,0,90, Arrow.rotation.w);
               TextPosition.anchoredPosition = new Vector2(0,0);
               TutorialText.text  = "if your ship is damaged add more crew to repair your ship";
               HpSlider.SetActive(true);
               ShipDamagedTable.SetActive(true);
            break;

            case 8:
               Arrow.anchoredPosition = new Vector2(-247,-200);
               TextPosition.anchoredPosition = new Vector2(0,0);
               TutorialText.text  = "Remember if your ship is damaged it will slowly sink, The more damage you receive the faster";
               Invoke("Stad",4f);
               transitionObject.SetActive(true);
            break;

            case 9:
                Arrow.anchoredPosition = new Vector2(252,-83);
                Arrow.eulerAngles = new Vector3(0,0,0);
               TextPosition.anchoredPosition = new Vector2(0,0);
               Enemy.GetComponent<EnemyShip>().Hp -= 2000f;
               TutorialText.text  = "Click button to board enemy ship and end tutorial";
            break;

        }
    }

    public void Stad()
    {
        TutorialStages = 9;
    }

    public void ChangeStage()
    {
        TutorialStages = PreviousStage + 1;
        CanChange = true;    
    }

    public void FirstStage()
    {
        TutorialStages = 0;
        ChangeStage();
    }

    public void AddMoreSailsCrew()
    {
        if(TutorialStages == 2)
        {
            if(CanChange)
            {
                SailSlider.SetActive(true);
                CanChange = false;
                PreviousStage = TutorialStages;
                TutorialStages = 0;
                Invoke("ChangeStage", 4f);
            }
        }   
    }
    public void EnterFireMode()
    {
        if(TutorialStages == 3)
        {
            if(CanChange)
            {
                FireModeButton.SetActive(true);
                CanChange = false;
                PreviousStage = TutorialStages;
                TutorialStages = 0;
                Invoke("ChangeStage", 4f);
            }
        }
    }

    public void Fire()
    {
        if(TutorialStages == 4)
        {
            if(CanChange)
            {
                 CanChange = false;
                PreviousStage = TutorialStages;
                TutorialStages = 0;
                Invoke("ChangeStage", 4f);
            }
        }
    }

    public void AddMoreCannonsCrew()
    {
        if(TutorialStages == 5)
        {
                if(CanChange)
                {
                    CannonsSlider.SetActive(true);
                    CanChange = false;
                    PreviousStage = TutorialStages;
                    TutorialStages = 0;
                    Invoke("ChangeStage", 4f);
                    Player.GetComponent<Ship_hp>().Health -= 30;
                }
            
        }   
    }

    public void AddMoreRepairCrew()
    {
        if(TutorialStages == 7)
        {
            if(CanChange)
            {
                CanChange = false;
                PreviousStage = TutorialStages;
                TutorialStages = 0;
                Invoke("ChangeStage", 4f);
            } 
        }   
    }

    public void AbordShip()
    {
        if(TutorialStages == 9)
        {
            transition.ChangeScene();
        }   
    }
}
