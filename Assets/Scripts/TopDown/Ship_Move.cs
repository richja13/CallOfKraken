using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ship_Move : MonoBehaviour
{
    public bool moving = false;
    public Vector3 targetPosition;
    private Vector3 iniTransformPosition;
    private float targetDistance;
    public float maxCrewNumber;
    public float turnSpeed;
    public float moveSpeed;
    public Slider moveSpeedSlider; 
    public Slider turnSpeedSlider;
    public Slider cannonReloadSlider;
    public float CrewNumber;
    public float OldCrewNumber;
    private bool cos = false;
    public float OldSailsCrewNumber;
    public float SailsCrewNumber;
    public float TurnCrewNumber;
    public float OldTurnCrewNumber;
    public float CannonCrewNumber;
    public float OldCannonCrewNumber;
    public float distance;
    public float Time1;
    public GameObject Tentacle;
    public Transform AcceleratorQuanternion;
    public GameObject Accelerator;
    public float TurnDifference;
    public float SailsDifference;
    public float CannonDifference;
    public bool CursorOnUI;
    Ray ray;
    RaycastHit hit;
    public GameObject ShopButton;
    public Text ResText;
    public GameObject CourseCircle;
    private bool CircleReached;
    private int fingerID = -1;
    public bool OnSails;
    public bool OnTurn;
    public bool OnCannons;
    bool DoubleClicked;
    public Joystick joystick;
    float Heding;
    float LastPostion;
    int TutorialStages = 1;
    public Text JOYSTICBACKGROUND;
    public SceneTransitionAnimationScript Transition;
    void Start()
    {
       

        OnSails = false;
        OnCannons = false;
        OnTurn = false;

        Application.targetFrameRate = 60;
        moveSpeedSlider.value = 0;
        turnSpeedSlider.value = 0;
        CannonCrewNumber = 0;
        OldSailsCrewNumber = SailsCrewNumber;
        OldTurnCrewNumber = TurnCrewNumber;
        OldCannonCrewNumber = CannonCrewNumber;
        maxCrewNumber = PlayerStatsScript.BoatCrew;
        
        CrewNumber = maxCrewNumber;
    }
    
    void Update()
    {
        //Debug.Log(CircleReached);
        
        //Debug.Log(Screen.currentResolution);
        //ResText.text = Screen.currentResolution + "RESOLUTION";

        //Screen.SetResolution(850, 425,true);
        //Screen.SetResolution(900,450, true);
        SailsCrewNumber = moveSpeedSlider.value;
        TurnCrewNumber = turnSpeedSlider.value;
        CannonCrewNumber = cannonReloadSlider.value + 100;

       TurnDifference = (TurnCrewNumber - OldTurnCrewNumber);
        SailsDifference = (SailsCrewNumber - OldSailsCrewNumber);
        
        CannonDifference = (CannonCrewNumber - OldCannonCrewNumber);

        if(!OnSails)
        {
            //OldSailsCrewNumber = SailsCrewNumber;
        }

        if(!OnTurn)
        {
            //OldTurnCrewNumber = TurnCrewNumber;
        }

        if(!OnCannons)
        {
            //OldCannonCrewNumber = CannonCrewNumber;
        }
        


        if (TurnCrewNumber > OldTurnCrewNumber)
        {
            if(CrewNumber > 0)
            {
                CrewNumber -= (TurnCrewNumber - OldTurnCrewNumber);
                OldTurnCrewNumber = TurnCrewNumber;
            }
            else 
            {
                if(CannonCrewNumber > 0)
                {
                    CannonCrewNumber -= TurnDifference;
                    cannonReloadSlider.value = CannonCrewNumber - 100;
                }
                else if(SailsCrewNumber > 0)
                {
                    SailsCrewNumber -= TurnDifference;
                    moveSpeedSlider.value = SailsCrewNumber;
                }
                else
                {
                    TurnCrewNumber = maxCrewNumber;
                    turnSpeedSlider.value = TurnCrewNumber;
                }
            }
           
        }
        else if (TurnCrewNumber < OldTurnCrewNumber) //Sprawdzić dlaczego działa tylko z CrewNumber > 0
        {
            CrewNumber += Mathf.Abs(OldTurnCrewNumber - TurnCrewNumber);
            OldTurnCrewNumber = TurnCrewNumber;
        }






        if (SailsCrewNumber > OldSailsCrewNumber) //Sprawdzić dlaczego działa tylko z CrewNumber > 0
        {
          if(CrewNumber > 0)
          {
            CrewNumber -= (SailsCrewNumber - OldSailsCrewNumber);
            OldSailsCrewNumber = SailsCrewNumber;
          }
          else
          {
              if(CannonCrewNumber > 0)
              {
                  CannonCrewNumber -= SailsDifference;
                  cannonReloadSlider.value = CannonCrewNumber - 100;

              }
              else if(TurnCrewNumber > 0)
              {
                TurnCrewNumber -= SailsDifference;
                turnSpeedSlider.value = TurnCrewNumber;
              }
              else
              {
                  SailsCrewNumber = maxCrewNumber;
                  moveSpeedSlider.value = SailsCrewNumber;
              }
          }
           // OldSailsCrewNumber = SailsCrewNumber;
        }
        else if (SailsCrewNumber < OldSailsCrewNumber) //Sprawdzić dlaczego działa tylko z CrewNumber > 0
        {
            
            CrewNumber += Mathf.Abs(SailsCrewNumber - OldSailsCrewNumber);
            OldSailsCrewNumber = SailsCrewNumber;
        }




        if (CannonCrewNumber > OldCannonCrewNumber)
        {
            if(CrewNumber > 0)
            {
                CrewNumber -= (CannonCrewNumber - OldCannonCrewNumber);
                OldCannonCrewNumber = CannonCrewNumber;
            }
            else
            {
                if(SailsCrewNumber > 0)
                {
                    SailsCrewNumber -= CannonDifference;
                    moveSpeedSlider.value = SailsCrewNumber;
                }
                else if(TurnCrewNumber > 0)
                {
                    TurnCrewNumber -= CannonDifference;
                    turnSpeedSlider.value = TurnCrewNumber ;
                }
                else
                {
                    CannonCrewNumber = maxCrewNumber;
                    cannonReloadSlider.value = CannonCrewNumber - 100;
                }
            }
            //OldCannonCrewNumber = CannonCrewNumber;
        }
        else if (CannonCrewNumber < OldCannonCrewNumber)
        {
            CrewNumber += Mathf.Abs(OldCannonCrewNumber - CannonCrewNumber);
            OldCannonCrewNumber = CannonCrewNumber;
        }
      
    #if !UNITY_EDITOR
     fingerID = 0;
    #endif

       /* if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(fingerID))
        {
           
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDistance = Vector3.Distance(targetPosition, transform.position);
            CourseCircle.transform.position = targetPosition;
            iniTransformPosition = transform.position;
            moving = true;
            CircleReached = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //moving = false;
        }
*/
        moveSpeed = (moveSpeedSlider.value/3) * 70;
        turnSpeed = (moveSpeedSlider.value / 50000f) * 5 ; //* targetDistance;


        //float Heding = Mathf.Atan2(-joystick.Horizontal,joystick.Vertical) * Mathf.Rad2Deg;

        //var RotateShip = new Quaternion(0,0,Heding * Mathf.Rad2Deg,transform.rotation.w);

       

        
        //transform.rotation = Quaternion.Euler(0f,0f,Heding * Mathf.Rad2Deg);
        
       // if (moving)
       // {
            Heding = Mathf.Atan2(-joystick.Horizontal,joystick.Vertical) * Mathf.Rad2Deg;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(transform.up * moveSpeed * Time.deltaTime);

            if(!Input.GetMouseButton(0) || Heding == 0)
            {
                 transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0,0,LastPostion)), Time.deltaTime * 13.5f / (moveSpeedSlider.value + 40f));
            }   
            else if(Input.GetMouseButton(0) && (Heding > 0 || Heding < 0)) 
            //(joystick.Horizontal > 0.05 && joystick.Horizontal > -0.05 || joystick.Vertical > 0.05 || joystick.Vertical > -0.05))
            {
                LastPostion = Heding;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0,0,Heding)), Time.deltaTime * 13.5f / (moveSpeedSlider.value + 40f));
            }

            //if(!Input.GetMouseButton(0) || EventSystem.current.IsPointerOverGameObject(fingerID))
            //{
                //(0.020f/(turnSpeed + 0.1f)));
                
                 // transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, Time.deltaTime * 0.1f);
                //
                
                
            //}
           // else
            //{
                //JOYSTICBACKGROUND.text= "BLAD 404" + Quaternion.Euler(new Vector3(0,0,Heding));
               // Heding = Mathf.Atan2(-joystick.Horizontal,joystick.Vertical) * Mathf.Rad2Deg;
               // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0,0,Heding)), Time.deltaTime * 0.023f/(turnSpeed + 0.1f));
                //var newRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.forward);
                // newRotation.x = 0f;
                //newRotation.y = 0f;
                //Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 0.023f/(turnSpeed + 0.1f));
           // }
             
            
     //   }

      //  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      //  if(Physics.Raycast(ray, out hit))
       // {
        
       // }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if(collision.gameObject.name == "GameEnd")
        {
            if(ProjectMaster.IActMissionNumber == 48)
            {
                //Transition.SceneName = "MainMenu2";
                //Transition.ChangeScene();
            }
        }


        if(collision.gameObject.name == "MichaelsShip")
        {
            if(ProjectMaster.IActMissionNumber == 5)
            {
                ProjectMaster.IActMissionNumber = 6;
            }
        }

        if(collision.gameObject.tag == "Horizont")
        {
            CircleReached = true;
        }

        if(collision.gameObject.name == "IslaMuerto")
        {
            if(ProjectMaster.IActMissionNumber < 2)
            {
                ProjectMaster.IActMissionNumber = 2;
            }
        }
    }


    void SliderFunction()
    {

    }

    public void CheckOnCannons()
    {
        OnCannons = true;
        OnSails = false;
        OnTurn = false;
    }

    public void CheckOnSails()
    {
        OnSails = true;
        OnCannons = false;
        OnTurn = false;
    }

    public void CheckOnTurn()
    {
        OnTurn  = true;
        OnSails = false;
        OnCannons = false;
    }

    public void OnTurnOver()
    {
        OnTurn = false;
    }

    public void OnSailsOver()
    {
        OnSails = false;
    }

    public void OnCannonsOver()
    {
        OnCannons = false;
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            ShopButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-258, -137f);
        }

        /* if (collision.gameObject.tag == "FireActivatorV2")
        {
            GetComponent<EnemyCannons>().TimerActivator = true;
        }

        if (collision.gameObject.tag == "FireActivator")
        {
            GetComponent<EnemyCannons>().TimerActivator3 = true;
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            ShopButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-258, -500f);
        }
    }

    public void ChangeSliderValue()
    {
        //OldSailsCrewNumber = SailsCrewNumber;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2) 
        {
            DoubleClicked = true;
        }
    }

}