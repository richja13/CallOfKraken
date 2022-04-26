using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannons : MonoBehaviour
{
    public GameObject CannonsL;
    public GameObject CannonsR;
    public GameObject cannon_ball_l;
    public GameObject cannon_ball_r;
    public Transform cannon1_l;
    public Transform cannon2_l;
    public Transform cannon3_l;
    public Transform cannon4_l;
    public Transform cannon5_l;
    public Transform cannon6_l;
    public Transform cannon7_l;
    public Transform cannon8_l;

    public Transform cannon1_r;
    public Transform cannon2_r;
    public Transform cannon3_r;
    public Transform cannon4_r;
    public Transform cannon5_r;
    public Transform cannon6_r;
    public Transform cannon7_r;
    public Transform cannon8_r;
    public float timer;
    public bool TimerActivator = false;
    public bool TimerActivator3 = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerActivator = GetComponentInChildren<ShootL>().shoot;
        TimerActivator3 = GetComponentInChildren<ShootR>().shoot;
        
        if (timer >= 240f)
        {
            timer = 0f;
        }
        
        if (TimerActivator3 == true)
        {
            timer += 3f;
          

            if (timer == 100f)
            {
                Instantiate(cannon_ball_r, cannon1_r.position, cannon1_r.rotation);
            }

            if (timer == 120f)
            {
                Instantiate(cannon_ball_r, cannon2_r.position, cannon2_r.rotation);
            }

            if (timer == 180f)
            {
                Instantiate(cannon_ball_r, cannon3_r.position, cannon3_r.rotation);
            }
            if (timer == 60f)
            {
                Instantiate(cannon_ball_r, cannon4_r.position, cannon4_r.rotation);
            }
            if (timer == 90f)
            {
                Instantiate(cannon_ball_r, cannon5_r.position, cannon5_r.rotation);
            }
            if (timer == 40f)
            {
                Instantiate(cannon_ball_r, cannon6_r.position, cannon6_r.rotation);
            }
            if (timer == 140f)
            {
                Instantiate(cannon_ball_r, cannon7_r.position, cannon7_r.rotation);
            }
            if (timer == 160f)
            {
                Instantiate(cannon_ball_r, cannon8_r.position, cannon8_r.rotation);
            }
            if (timer >= 240)
            {
                GetComponent<EnemyShip>().FireMode = false;
                GetComponent<EnemyShip>().TIMER1 = 0;
                GetComponent<EnemyShip>().TimerTrue = false;
                GetComponent<EnemyShip>().moving = false;
            }
        }

        if (TimerActivator == true)
        {

            timer += 1;
            if (timer == 70f)
            {
                Instantiate(cannon_ball_l, cannon1_l.position, cannon1_l.rotation);
            
            }
            if (timer == 90f)
            {
                Instantiate(cannon_ball_l, cannon2_l.position, cannon2_l.rotation);
           
            }
            if (timer == 130f)
            {
                Instantiate(cannon_ball_l, cannon3_l.position, cannon3_l.rotation);
           
            }
            if (timer == 100f)
            {
                Instantiate(cannon_ball_l, cannon4_l.position, cannon4_l.rotation);
  
            }
            if (timer == 120f)
            {
                Instantiate(cannon_ball_l, cannon5_l.position, cannon5_l.rotation);
        
            }
            if (timer == 150)
            {
                Instantiate(cannon_ball_l, cannon6_l.position, cannon6_l.rotation);
         
            }
            if (timer == 170)
            {
                Instantiate(cannon_ball_l, cannon7_l.position, cannon7_l.rotation);
          
            }
            if (timer == 160)
            {


                Instantiate(cannon_ball_l, cannon8_l.position, cannon8_l.rotation);
    
            }
            if (timer >= 240)
            {
                GetComponent<EnemyShip>().FireMode = false;
                //GetComponent<EnemyShip>().TIMER1 = 0;
                GetComponent<EnemyShip>().TimerTrue = false;
                GetComponent<EnemyShip>().moving = false;
            }
        }
    }           
}
    

