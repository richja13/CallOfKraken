using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeManagerScript : MonoBehaviour
{
    public Slider Timer;
    public GameObject Player;
    public float Crew;
    public Text CrewText;
    public float timeRemaining;
    public int Kegs;
    public List<Sprite> BommPlaceSprite;
    public bool Collected;

    // Start is called before the first frame update
    void Start()
    {
        Timer.maxValue = PlayerStatsScript.BoatCrew/2;
        timeRemaining = Timer.maxValue;
        Timer.value = Timer.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
          if(!Collected)
          {
            //Crew = Timer.value;
            CrewText.text = Mathf.FloorToInt(timeRemaining) + "";
            timeRemaining -= Time.deltaTime/2;
            PlayerStatsScript.BoatCrew -= Time.deltaTime/2;
            Timer.value -= Time.deltaTime/2;
          }
        }
        else
        {
          if(!Collected)
          {
            SceneManager.LoadScene("topDown");
          }
        }

        switch(Kegs)
        {
            case 0: 
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[0];
            break;

            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[1];
            break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[2];
            break;

            case 3:
                  this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[3];
            break;

            case 4:
              this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[4];
            break;

            case 5:
             Collected = true;
              this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
              if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 9)
              {
                SceneManager.LoadScene("topDown");
              }
              else
              {
                if(ProjectMaster.IActMissionNumber == 8)
                {
                  ProjectMaster.IActMissionNumber = 9;
                }

                if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }

                if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }
              }
            break;
          
            case 6:
             Collected = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
                 if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 10)
              {
              SceneManager.LoadScene("topDown");
                }
              else
              {
                  if(ProjectMaster.IActMissionNumber == 8)
                  {
                    ProjectMaster.IActMissionNumber = 9;
                  }

                    if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }

                   if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }
              }
            break;
               case 7:
                Collected = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
                 if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 10)
              {
              SceneManager.LoadScene("topDown");
                }
              else
              {
                if(ProjectMaster.IActMissionNumber == 8)
                {
                  ProjectMaster.IActMissionNumber = 9;
                }
                
                  if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }

                   if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }
              }
            break;
               case 8:
                Collected = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
                    if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 10)
              {
              SceneManager.LoadScene("topDown");
                }
              else
              {
                if(ProjectMaster.IActMissionNumber == 8)
                {
                  ProjectMaster.IActMissionNumber = 9;
                }

                  if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }

                   if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }
              }
            break;
               case 9:
                Collected = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
                    if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 10)
              {
              SceneManager.LoadScene("topDown");
                }
              else
              {
                if(ProjectMaster.IActMissionNumber == 8)
                {
                  ProjectMaster.IActMissionNumber = 9;
                }

                  if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }

                   if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }
              }
            break;
               case 10:
                Collected = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = BommPlaceSprite[5];
                    if(ProjectMaster.IActMissionNumber < 8 && ProjectMaster.IActMissionNumber > 10)
              {
                SceneManager.LoadScene("topDown");
              }
              else
              {
                if(ProjectMaster.IActMissionNumber == 8)
                {
                  ProjectMaster.IActMissionNumber = 9;
                }

                  if(ProjectMaster.IActMissionNumber == 16)
                {
                  ProjectMaster.IActMissionNumber = 17;
                }
                
                   if(ProjectMaster.IActMissionNumber == 28)
                {
                  ProjectMaster.IActMissionNumber = 29;
                }
              }
            break;

        }
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Kegs += Player.GetComponent<PlayerMovement>().Keg;
            Player.GetComponent<PlayerMovement>().Keg = 0;
        }
    }

}
