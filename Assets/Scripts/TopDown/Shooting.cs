using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using TMPro;



public class Shooting : MonoBehaviour
{

    public float CamClose;
    public float CamFar;
    private bool ShootingLeft;
    private bool ShootingRight;
    public Button SRright;
    public Button SLeft;

    public float firing;
    public float timer = 0;
    public GameObject cannon_ball_l;
    public GameObject cannon_ball_r;
    public Transform cannon1_r;
    public Transform cannon2_r;
    public Transform cannon3_r;
    public Transform cannon4_r;
    public Transform cannon5_r;
    public Transform cannon6_r;
    public Transform cannon7_r;
    public Transform cannon8_r;

    public Transform cannon1_l;
    public Transform cannon2_l;
    public Transform cannon3_l;
    public Transform cannon4_l;
    public Transform cannon5_l;
    public Transform cannon6_l;
    public Transform cannon7_l;
    public Transform cannon8_l;
    public bool timer2 = false;
    public bool timer3 = false;
    public Slider SliderTimer;
    public float Test;
    public bool CameraInShootingMode;
    public bool Shooting_mode = false;
    public Button yourButton;

    public CamShake cameraShake;
    public float CamShakeatm;
    public float CamShakeLght;

    public List<Slider> ReloadSlider;
    
    int TimerForSlider;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(ShootingMode);
        
    }

    // Update is called once per frame 
    void Update()
    {
      
        Test = ((SliderTimer.value * 5) - 220);

       

        if(timer == 0)
        {
            TimerForSlider = 100;
        }
        else
        {
             TimerForSlider = Mathf.FloorToInt((-(timer/Test)*100));
        }

        ReloadSlider[0].value = TimerForSlider;
        ReloadSlider[1].value = TimerForSlider;

      
        
    
        if (Shooting_mode == true)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CamClose , Time.deltaTime);

        }
        else
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, CamFar, Time.deltaTime);
            Shooting_mode = false;
        }



        
    if (Shooting_mode == true)
        {

            SLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(91, -10);
            SRright.GetComponent<RectTransform>().anchoredPosition = new Vector2(-91 , -10);

        if (Input.GetKeyDown(KeyCode.A) || ShootingLeft == true)
        {
            ShootingLeft = false;
            timer2 = true;       
        }
        if (timer2 == true)
        {      
                timer += 2;
                if (timer >= Test * -1)
                {
                    timer = 0;
                    timer2 = false;
                }
            
                

                if (timer == 10f)
            {
                Instantiate(cannon_ball_l, cannon1_l.position, cannon1_l.rotation);
                    

                }

                if (timer == 10f)
            {
                Instantiate(cannon_ball_l, cannon2_l.position, cannon2_l.rotation);
                 cameraShake.Shake(CamShakeatm,CamShakeLght);

                }

                if (timer == 8f)
            {
                Instantiate(cannon_ball_l, cannon3_l.position, cannon3_l.rotation);
         cameraShake.Shake(CamShakeatm,CamShakeLght);

                }
                
                if (timer == 10f)
            {
                Instantiate(cannon_ball_l, cannon4_l.position, cannon4_l.rotation);
            cameraShake.Shake(CamShakeatm,CamShakeLght);

                }
                
                if (timer == 15f)
            {
                Instantiate(cannon_ball_l, cannon5_l.position, cannon5_l.rotation);
    cameraShake.Shake(CamShakeatm,CamShakeLght);

                }

                if (timer == 16f)
            {
                Instantiate(cannon_ball_l, cannon6_l.position, cannon6_l.rotation);
    cameraShake.Shake(CamShakeatm,CamShakeLght);

                }
                
                if (timer == 18f)
            {
                    Instantiate(cannon_ball_l, cannon7_l.position, cannon7_l.rotation);
      cameraShake.Shake(CamShakeatm,CamShakeLght);

                }
                
                if (timer == 16f)
            {
                Instantiate(cannon_ball_l, cannon8_l.position, cannon8_l.rotation);
      cameraShake.Shake(CamShakeatm,CamShakeLght);

                }                
            }
        }
        else
        {
            SLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-900, 51);
            SRright.GetComponent<RectTransform>().anchoredPosition = new Vector2(900, 51);
        }


        if (Input.GetKeyDown(KeyCode.D) || ShootingRight == true)
        {
            ShootingRight = false;
            timer3 = true;
        }
        if (timer3 == true)
        {
            timer += 2f;
        
            if (timer >= Test * -1)
            {
                timer = 0;
                timer3 = false;
            }
            if (timer == 10f)
            {
                Instantiate(cannon_ball_r, cannon1_r.position, cannon1_r.rotation);
      cameraShake.Shake(CamShakeatm,CamShakeLght);
            }

            if (timer == 10f)
            {
                Instantiate(cannon_ball_r, cannon2_r.position, cannon2_r.rotation) ;
cameraShake.Shake(CamShakeatm,CamShakeLght);
            }

            if (timer == 18f)
            {
                Instantiate(cannon_ball_r, cannon3_r.position, cannon3_r.rotation);
    cameraShake.Shake(CamShakeatm,CamShakeLght);
                }
            if (timer == 10f)
            {
                Instantiate(cannon_ball_r, cannon4_r.position, cannon4_r.rotation);
    cameraShake.Shake(CamShakeatm,CamShakeLght);
                }
            if (timer == 9f)
            {
                Instantiate(cannon_ball_r, cannon5_r.position, cannon5_r.rotation);
     cameraShake.Shake(CamShakeatm,CamShakeLght);
                }
            if (timer == 16f)
            {
                Instantiate(cannon_ball_r, cannon6_r.position, cannon6_r.rotation);
        cameraShake.Shake(CamShakeatm,CamShakeLght);
                }
            if (timer == 14f)
            {
                Instantiate(cannon_ball_r, cannon7_r.position, cannon7_r.rotation);
              cameraShake.Shake(CamShakeatm,CamShakeLght);
                    

            }
            if (timer == 13f)
            {
                    Instantiate(cannon_ball_r, cannon8_r.position, cannon8_r.rotation);
                cameraShake.Shake(CamShakeatm,CamShakeLght);

            }
        }
 }

   

    void ShootingMode()
    {
        if (Shooting_mode == true)
        {
            Shooting_mode = false;
        }
        else
        {
            Shooting_mode = true;
        }
    }
    void Shake()
    {
        
        CameraShaker.Instance.ShakeOnce(1f, 1f, 0.2f, 0.5f);
    }

    public void ShootL()
    {
        ShootingLeft = true;
    }

    public void ShootR()
    {
        ShootingRight = true;
    }

}   


    
    

