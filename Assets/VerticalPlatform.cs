using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float WaitTime;
    public Joystick joystick;
    public Button DownButton;
    public Button UpButton;
    private bool DetectPlayer = false;
    public GameObject Player;
    private float PlayerDistance = 2.5f;

    private void Start()
    {
        PlayerDistance = 0.5f;
     effector = GetComponent<PlatformEffector2D>();
    }

 private void Update()
 {

        if (Vector2.Distance(Player.transform.position, transform.position) < PlayerDistance) //&& Input.GetButtonDown("ButtonDown"))
        {
         
            //Rotate();
            //Debug.Log("RANDY DANDY O");
            UpButton.onClick.AddListener(Rotate);
            DownButton.onClick.AddListener(Rotate2);
        }


        //Debug.Log(Vector2.Distance(Player.transform.position, transform.position));

        /* if (Input.GetKeyUp(KeyCode.S) || joystick.Vertical < 0)
         {
             WaitTime = 0.2f;
         }

         if (Input.GetKey(KeyCode.S)  || joystick.Vertical < 0)
         {
             if (WaitTime <= 0)
             {
                 effector.rotationalOffset = 180f;
                 WaitTime = 0.2f;
             }
             else
             {
                 WaitTime -= Time.deltaTime;
             }
         }
         */
    }

    public void Rotate2()
    {
     
        if (WaitTime <= 0)
        {
            effector.rotationalOffset = 180f;
            WaitTime = 0.2f;
        }
        else
        {
            WaitTime -= Time.deltaTime;
        }
    }


    public void Rotate()
    {
        effector.rotationalOffset = 0f;
    }
}
