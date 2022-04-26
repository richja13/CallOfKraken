using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProjectMaster : MonoBehaviour
{
   //Missions I
    public static int IActMissionNumber = 1;
    public Text MissionText;
    public RectTransform MissionMark;
    public GameObject Player;
    public GameObject MichaelShip;
    public GameObject AmeliaShip;
    public GameObject MaynardShip;
    public GameObject AdmiralShip;
    public GameObject JackShip;
    static int FirstTime;

    void Awake()
    {
      
    }

    void Start()
    {
        FirstTime = PlayerPrefs.GetInt("FirstTime");
    
        if(FirstTime == 0)
        {
           
            FirstTime = 1;
            IActMissionNumber = 0;

        }
        else
        {
            IActMissionNumber = PlayerPrefs.GetInt("MissionNumber");
        }

        if(IActMissionNumber == 4)
        {
             if(SceneManager.GetActiveScene().name == "TropicalForest")
            {
                Player.transform.localPosition = new Vector3(316.494f,-255.352f,80);
            }
            else if(SceneManager.GetActiveScene().name == "CaveIsland2")
            {
                Player.transform.position = new Vector2();
            }
        }

        if(IActMissionNumber == 5)
        {
            //Player.transform.position = new Vector2(-211,150);
        }

        if(IActMissionNumber == 10)
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                //Player.transform.localPosition = new Vector3(1677,-514);
            }
        }

        if(IActMissionNumber >= 13 && IActMissionNumber <= 18)
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-3439,-1246);
            }  
        }

        if(IActMissionNumber == 11 || IActMissionNumber == 12) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(1980,-1582);
            }  
        }

          if(IActMissionNumber == 19 || IActMissionNumber == 20 || IActMissionNumber == 21 || IActMissionNumber == 22) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-3349,-1240);
            }  
        }

        if(IActMissionNumber == 23 || IActMissionNumber == 24) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-2025,930);
            }  
        }

        if( IActMissionNumber == 25 || IActMissionNumber == 26 || IActMissionNumber == 27 || IActMissionNumber == 28 || IActMissionNumber == 29 || IActMissionNumber == 30 || IActMissionNumber == 31 || IActMissionNumber == 32) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-410,2514);
            }  
        }

        if( IActMissionNumber == 33 || IActMissionNumber == 34) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(2394,1463);
            }  
        }

         if( IActMissionNumber == 35 || IActMissionNumber == 36 || IActMissionNumber == 37) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-3439,-1246);
            }  
        }

         if( IActMissionNumber == 38 || IActMissionNumber == 39 || IActMissionNumber == 40) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-332,1076);
            }  
        }

           if( IActMissionNumber == 41 || IActMissionNumber == 42 || IActMissionNumber == 43) 
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                Player.transform.localPosition = new Vector3(-332,1076);
            }  
        }

        if( IActMissionNumber == 44 || IActMissionNumber == 45 || IActMissionNumber == 46 || IActMissionNumber == 47 || IActMissionNumber == 48 || IActMissionNumber == 49)  
        {
            if(SceneManager.GetActiveScene().name == "topDown")
            {
                 Player.transform.localPosition = new Vector3(-332,1076);
            }  
        }
    }


    void Update()
    {

  

        PlayerPrefs.SetInt("FirstTime",FirstTime);
        PlayerPrefs.SetInt("MissionNumber",IActMissionNumber);

        if(Input.GetKeyDown(KeyCode.C))
        {
            IActMissionNumber += 1;
        }

        if(Input.GetKey(KeyCode.L))
        {
            Debug.Log("GOLD");
            PlayerStatsScript.BoatCrew += 1;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            IActMissionNumber -= 1;
        }

        

        if(Input.GetKeyDown(KeyCode.U))
        {
            PlayerStatsScript.GunDamage += 1;
            PlayerStatsScript.AttackDmg += 1;
            PlayerStatsScript.BoatAttack += 1;
            PlayerStatsScript.BoatHp += 1000;
            PlayerStatsScript.Hp += 100;
        }

        if(SceneManager.GetActiveScene().name == "IslaDePoco")
        {
            if(IActMissionNumber == 1)
            {
                IActMissionNumber = 11;
            }
        }

        switch(IActMissionNumber)
        {
            case 0:
           
                IActMissionNumber = 1;
            break;

            case 1:
                MissionText.text = "Sail to island";
                MissionMark.anchoredPosition = new Vector2(1.81f,-0.88f);
            break;

            case 2:
                MissionText.text = "Defeat Capt.Michael Ships";
                MissionMark.anchoredPosition = new Vector2(1.81f,-0.88f);
            break;
                
            case 3:
                MissionText.text = "Find Michael's hideout on island";
                MissionMark.anchoredPosition = new Vector2(1.81f,-0.88f);
            break;

            case 4:
                MissionText.text = "EscapeIsland";

            break;

            case 5:
                
                 MissionText.text = "Find Michael ship";
                 MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
            break;

            case 6:
                 MissionText.text = "Defeat Michael ship";
                 MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
            break;
            
            case 7:
                 MissionText.text = "Board Ship";
                 MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
            break;

            case 8:
                MissionText.text = "Find 5 gunpowder barells";
                MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);//MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
            break;

            case 9:
                MissionText.text = "Kill Captain Michael";
                MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);//MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
            break;

         //   case 10:
               //// MissionText.text = "Revange Your Friend";
             //   MissionMark.anchoredPosition = new Vector2(6.33f,-2.41f);
        //    break;

            case 10:
                MissionMark.anchoredPosition = new Vector2(7.03f,-4.26f);
                MissionText.text = "Sail to Island";
            break;

            case 11:
                MissionMark.anchoredPosition = new Vector2(7.03f,-4.26f);
                MissionText.text = "Collect informations about White Galleon";
            break;

            case 12:
                MissionText.text = "Find Amelia Hideout";
                MissionMark.anchoredPosition = new Vector2(-5.19f,-4.02f);
            break;

            case 13:
                MissionMark.anchoredPosition = new Vector2(7.03f,-4.26f);
                MissionText.text = "Find Jurnal";
            break;

            case 14:
                MissionMark.anchoredPosition = new Vector2(-3.92f,-2.21f);
                MissionText.text = "Search for Capt.Amelia Ship";
            break;

            case 15:
                MissionMark.anchoredPosition = new Vector2(-3.92f,-2.21f);
                MissionText.text = "Defeat Queen of skeletons";
            break;

            case 16:
                MissionMark.anchoredPosition = new Vector2(7.03f,-4.26f);
                MissionText.text = "Find 5 Gunpowder Barells";
            break;

            case 17:
                MissionText.text = "Talk to Amelia"; MissionMark.anchoredPosition = new Vector2(7.03f,-4.26f);
            break;

            case 18:
                MissionText.text = "Follow the map";
                MissionMark.anchoredPosition = new Vector2(-5.5f,-0.32f);
            break;

            case 19:
                MissionText.text = "Dig for the Magma chest";
            break;

            case 20:
                MissionText.text = "Exit Island";
            break;

            case 21:
                MissionText.text = "Find another chest";
                MissionMark.anchoredPosition = new Vector2(-1.65f,1.02f);
            break;

            case 22:
                MissionText.text = "Search for Tropical chest";
            break;

             case 23:
                MissionText.text = "Escape Island";
            break;

            case 24:
                MissionText.text = "Attack Maynard Fort";
                MissionMark.anchoredPosition = new Vector2(1.37f,4.79f);
            break;

            case 25:
                MissionText.text = "Find Legendary chest map";
            break;

            case 26:
                    MissionText.text = "Exit Fort";
            break;

            case 27:
                MissionText.text = "Attack Officer Maynard Ship";
                MissionMark.anchoredPosition = new Vector2(6.03f,4.54f);
            break;

            case 28:
                MissionText.text = "Find 5 gunpowder barells";
                MissionMark.anchoredPosition = new Vector2(6.03f,4.54f);
            break;

            case 29:
                MissionText.text = "Kill Maynard";
               MissionMark.anchoredPosition = new Vector2(6.03f,4.54f);
            break;

            case 30:
                MissionText.text = "Attack Admiral Alexander Ship";
                MissionMark.anchoredPosition = new Vector2(4.91f,1.08f);
            break;

            case 31:
                MissionText.text = "Find Ship's hold Key, Open hold";
                 MissionMark.anchoredPosition = new Vector2(4.91f,1.08f);
            break;

            case 32:
                MissionText.text = "Attack Imperial Stronghold";
                MissionMark.anchoredPosition = new Vector2(6.67f,1.08f);
            break;

            case 33:
                MissionText.text = "Meet the Admiral Alexander";
            break;

            case 34:
                MissionText.text = "Sail to Kraken Chest Location";
                MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;
            
            case 35:
                MissionText.text = "Find Admiral";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 36:
                MissionText.text = "Escape the cursed crew";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 37:
                MissionText.text = "Break the Mythical Sword";
                MissionMark.anchoredPosition = new Vector2(6.42f,0.61f);
            break;

            case 38:
                MissionText.text = "Defeat Fallen Crew";
               MissionMark.anchoredPosition = new Vector2(6.42f,0.61f);
            break;

            case 39:
                MissionText.text = "Escape Island";
                MissionMark.anchoredPosition = new Vector2(6.42f,0.61f);
            break;

            case 40:
                MissionText.text = "Find Black Mary";
                MissionMark.anchoredPosition = new Vector2(6.5f,5.05f);
            break;

            case 41:
                MissionText.text = "Pick up Kraken chest";
                MissionMark.anchoredPosition = new Vector2(6.5f,5.05f);
            break;

            case 42:
                MissionText.text = "Exit Island";
                MissionMark.anchoredPosition = new Vector2(6.5f,5.05f);
            break;

            case 43:
                 MissionText.text = "Attack cursed Ship";
                MissionMark.anchoredPosition = new Vector2(-0.13f,2.22f);
            break;
            
            case 44:
                 MissionText.text = "Go to Island";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 45:
                 MissionText.text = "Find Captain Jack";
                  MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 46:
                MissionText.text = "Kill Jack";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 47:
                MissionText.text = "Rescue your father";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 48:
                MissionText.text = "Leave Paradise sea";
                 MissionMark.anchoredPosition = new Vector2(1.57f,1.51f);
            break;

            case 49:
                MissionText.text = "The End?";
            break;
        }

        if(IActMissionNumber == 5 || IActMissionNumber == 6 || IActMissionNumber == 7)
        {
            MichaelShip.SetActive(true);
        }
        else
        {
            MichaelShip.SetActive(false);
        }


        if(IActMissionNumber == 14 || IActMissionNumber == 15)
        {
           
            AmeliaShip.SetActive(true);
        }
        else
        {
            AmeliaShip.SetActive(false);
        }

        if(IActMissionNumber == 27 || IActMissionNumber == 28 || IActMissionNumber == 29)
        {
            MaynardShip.SetActive(true);
        }
        else
        {
            MaynardShip.SetActive(false);
        }

        if(IActMissionNumber == 30 || IActMissionNumber == 31)
        {
            AdmiralShip.SetActive(true);
        }
        else
        {
            AdmiralShip.SetActive(false);
        }

        if(IActMissionNumber == 43 || IActMissionNumber == 44)
        {
            JackShip.SetActive(true);
        }
        else
        {
            JackShip.SetActive(false);
        }
    }

  public void CloseBooks(int Mission)
  {
    IActMissionNumber = Mission;
  }
}
