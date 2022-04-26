using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Camera mainCam;
    float ShakeAmount = 0;
    
    void Awake()
    {
        if(mainCam == null)mainCam = Camera.main;
    }

    void Start()
    {
        mainCam.transform.localPosition  = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Shake(0.1f,0.2f);
        }
    }

    public void Shake(float amt,float lght)
    {
        ShakeAmount = amt;
        InvokeRepeating("BeginShake",0,0.01f);
        Invoke("StopShake",lght);
    }

    void BeginShake()
    {
        if(ShakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;
            float offsetX = Random.value * ShakeAmount * 2 - ShakeAmount;
            float offsetY = Random.value * ShakeAmount *  2 - ShakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition  = Vector3.Slerp(mainCam.transform.localPosition,Vector3.zero,0.2f);
    }


}
