using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToIslandScript : MonoBehaviour
{
    public SceneTransitionAnimationScript transition;
    public Button GoToIsland;
    public Button OutPostButton;
    public Button AbordSloop;
    public Button AbordShip;
    public GameObject BusinessPanel;
    public GameObject BusinessPanel2;
    public GameObject BusinessPanel3;
    public GameObject BusinessPanel4;
    
    public void Update()
    {
        OutPostButton = GameObject.FindGameObjectWithTag("Door").GetComponent<Button>();
    }
    
    public void GoToIslaMuerta()
    {   
        if(ProjectMaster.IActMissionNumber >= 3)
        {
            transition.SceneName = "TropicalForest";
            transition.ChangeScene();
        }
        
        //SceneManager.LoadScene("TropicalForest");
    }

    public void GoToIslaLoco()
    {
        transition.SceneName = "Isla de loco";
        transition.ChangeScene();

        if(ProjectMaster.IActMissionNumber == 12)
        {
            ProjectMaster.IActMissionNumber = 13;
        }
        //SceneManager.LoadScene("Isla de loco");
    }

    public void NewIsland()
    {
        transition.SceneName = "NewIsland";
        transition.ChangeScene();
        
        if(ProjectMaster.IActMissionNumber == 21)
        {
            ProjectMaster.IActMissionNumber = 22;
        }
    }

    public void GoToSkeletonIsland()
    {
        transition.SceneName = "PirateForest";
        transition.ChangeScene();
    }

    public void AttackCapitanMichael()
    {
        transition.SceneName = "MichaelsShip";
        transition.ChangeScene();
        //SceneManager.LoadScene("MichaelsShip");
        if(ProjectMaster.IActMissionNumber == 7)
        {
            ProjectMaster.IActMissionNumber = 8;
        }
    }

    public void AttackMaynardShip()
    {
        transition.SceneName = "OfficerMaynardShip";
        transition.ChangeScene();
        //if(ProjectMaster.IActMissionNumber == 27)
       // {
            ProjectMaster.IActMissionNumber = 28;
      //  }
    }

    public void AttackSkeletonQueen()
    {
        transition.SceneName = "SkeletonsQueenShip";
        transition.ChangeScene();
        if(ProjectMaster.IActMissionNumber == 14)
        {
            ProjectMaster.IActMissionNumber = 15;
        }
    }

    public void ShipWreck()
    {
        transition.SceneName = "ShipWrecIsland";
        transition.ChangeScene();      
    }

    public void IslaDePoco()
    {
        transition.SceneName = "IslaDePoco";
        transition.ChangeScene();
        
        if(ProjectMaster.IActMissionNumber == 10)
        {
            ProjectMaster.IActMissionNumber = 11;
        }
    }

    public void FreedomIsland()
    {
        transition.SceneName = "FreedomIsland";
        transition.ChangeScene();
        if(ProjectMaster.IActMissionNumber == 18)
        {
            ProjectMaster.IActMissionNumber = 19;
        }
    }

    public void RainIsland()
    {
        transition.SceneName = "RainIsland";
        transition.ChangeScene();
    }

    public void MaynardFort()
    {
        transition.SceneName = "MaynardFort";
        transition.ChangeScene();
        if(ProjectMaster.IActMissionNumber == 24)
        {
            ProjectMaster.IActMissionNumber = 25;
        }
    }

    public void AdmiralShip()
    {
        transition.SceneName = "AdmiralAlexanderShip";
        transition.ChangeScene();
        if(ProjectMaster.IActMissionNumber == 30)
        {
            ProjectMaster.IActMissionNumber = 31;
        }
    }

    public void AdmiralFort()
    {
        transition.SceneName = "AdmiralAlexanderFort";
        transition.ChangeScene();
        if(ProjectMaster.IActMissionNumber == 32)
        {
            ProjectMaster.IActMissionNumber = 33;
        }
    }

    public void Buisness2Function()
    {
        BusinessPanel2.GetComponent<Buisness2Script>().ClosePanelMenu();
    }
    public void BoneIsland()
    {
        
        
        if(ProjectMaster.IActMissionNumber == 44 || ProjectMaster.IActMissionNumber == 45)
        {
            transition.SceneName = "FinalFight";
            ProjectMaster.IActMissionNumber = 45;
            transition.ChangeScene();
        }
        else
        {
            if(ProjectMaster.IActMissionNumber == 34)
            {
                ProjectMaster.IActMissionNumber = 35;
            }
            transition.SceneName = "BoneIsland";

            transition.ChangeScene();
        }
      
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "MichaelsShip")
        {
            AbordSloop.onClick.AddListener(AttackCapitanMichael);
            AbordShip.onClick.AddListener(AttackCapitanMichael);
        }

        if(collision.gameObject.name == "SkeletonQueenShip")
        {
            AbordShip.onClick.AddListener(AttackSkeletonQueen);
            AbordSloop.onClick.AddListener(AttackSkeletonQueen);
        }

        if(collision.gameObject.name == "MaynardShip")
        {
            AbordShip.onClick.AddListener(AttackMaynardShip);
            AbordSloop.onClick.AddListener(AttackMaynardShip);
        }

        if(collision.gameObject.name == "AdmiralShip")
        {
            AbordShip.onClick.AddListener(AdmiralShip);
            AbordSloop.onClick.AddListener(AdmiralShip);
        }



        if(collision.gameObject.name == "TruthIsland")
        {
            GoToIsland.onClick.AddListener(GoToIslaLoco);
        }

        if(collision.gameObject.name == "IslaMuerto")
        {
            GoToIsland.onClick.AddListener(GoToIslaMuerta);
        }

        if(collision.gameObject.name == "SkeletonIsland")
        {
            OutPostButton.onClick.AddListener(BusinessPanel.GetComponent<BuisnessScript>().ClosePanelMenu);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        if(collision.gameObject.name == "OlimpusCity") 
        {
            OutPostButton.onClick.AddListener(Buisness2Function);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        if(collision.gameObject.name == "ZabrzusOutpost")
        {
            OutPostButton.onClick.AddListener(BusinessPanel2.GetComponent<Buisness2Script>().ClosePanelMenu);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        if(collision.gameObject.name == "ConfidentusOutpost")
        {
            OutPostButton.onClick.AddListener(BusinessPanel2.GetComponent<Buisness2Script>().ClosePanelMenu);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        

        if(collision.gameObject.name == "IslaDePoco")
        {
            GoToIsland.onClick.AddListener(IslaDePoco);
        }

        if(collision.gameObject.name == "ShipWreckIsland")
        {
            GoToIsland.onClick.AddListener(ShipWreck);
        }

        if(collision.gameObject.name == "FreedomIsland")
        {
            GoToIsland.onClick.AddListener(FreedomIsland);
        }

        if(collision.gameObject.name == "NewIsland")
        {
            GoToIsland.onClick.AddListener(NewIsland);
        }

        if(collision.gameObject.name == "MaynardFort")
        {
            GoToIsland.onClick.AddListener(MaynardFort);
        }

        if(collision.gameObject.name == "MaynardShip")
        {
            GoToIsland.onClick.AddListener(AttackMaynardShip);
        }

        if(collision.gameObject.name == "AdmiralShip")
        {
            GoToIsland.onClick.AddListener(AdmiralShip);
        }

        if(collision.gameObject.name =="AdmiralFort")
        {
            GoToIsland.onClick.AddListener(AdmiralFort);
        }

        if(collision.gameObject.name == "BonesIsland")
        {
            GoToIsland.onClick.AddListener(BoneIsland);
            
        }

        if(collision.gameObject.name == "RainIsland")
        {
            GoToIsland.onClick.AddListener(RainIsland);
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
    /*        if(collision.gameObject.name == "MichaelsShip")
        {
            AbordSloop.onClick.AddListener(null);
            AbordShip.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "SkeletonQueenShip")
        {
            AbordShip.onClick.AddListener(null);
            AbordSloop.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "MaynardShip")
        {
            AbordShip.onClick.AddListener(null);
            AbordSloop.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "AdmiralShip")
        {
            AbordShip.onClick.AddListener(null);
            AbordSloop.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "TruthIsland")
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "IslaMuerto" && ProjectMaster.IActMissionNumber >= 3)
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "SkeletonIsland")
        {
            GoToIsland.onClick.AddListener(null);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        if(collision.gameObject.name == "OlimpusCity") 
        {
            GoToIsland.onClick.AddListener(null);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
        }

        if(collision.gameObject.name == "ZabrzusOutpost")
        {
            //GoToIsland.onClick.AddListener(BusinessPanel2.GetComponent<Buisness2Script>().ClosePanelMenu);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
             GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "ConfidentusOutpost")
        {
            //GoToIsland.onClick.AddListener(BusinessPanel2.GetComponent<Buisness2Script>().ClosePanelMenu);
            //GoToIsland.onClick.AddListener(GoToSkeletonIsland);
             GoToIsland.onClick.AddListener(null);
        }



        if(collision.gameObject.name == "IslaDePoco")
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "ShipWreckIsland")
        {
            //GoToIsland.onClick.AddListener(ShipWreck);
               GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "FreedomIsland")
        {
              GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "NewIsland")
        {
               GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "MaynardFort")
        {
              GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "MaynardShip")
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "AdmiralShip")
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name =="AdmiralFort")
        {
            GoToIsland.onClick.AddListener(null);
        }

        if(collision.gameObject.name == "BoneIsland")
        {
            GoToIsland.onClick.AddListener(null);
        }
          */
    }
    
}
