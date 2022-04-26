using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;

public class CamFaollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target1;
    public float RandomShakeM;
    public float RandomShakeR;
    private bool CameraShake;
    private float Timer = 50f;
    public bool Huricane = false;
    public RectTransform EscapeMenu;
    public bool Shop = false;

    // Start is called before the first frame update
    void Start()
    {
  
    }
    
    // Update is called once per frame
    void Update()
    {

       // Screen.SetResolution(850, 425, true);
       Screen.SetResolution(1200,600, true);
        Application.targetFrameRate = 35;
        
        Debug.unityLogger.logEnabled = false;

        RandomShakeM = Random.Range(0.01f, 0.8f);
        RandomShakeR = Random.Range(0.01f, 0.07f);

        Vector3 newPosition = Target1.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        Timer -= 1f;
        if (Timer <= 0)
        {
            Timer = 50f;
            CameraShake = true;
        }
        else if (Timer > 0)
        {
            CameraShake = false;
        }

        if (Shop == true)
        {
            EscapeMenu.anchoredPosition = new Vector2(0, 0);
        }
        else if(Shop == false)
        {
            EscapeMenu.anchoredPosition = new Vector2(1400, 1900f);
        }

        if (CameraShake == true)
        {
            CameraShaker.Instance.StartShake(RandomShakeM, RandomShakeR, 1f * Time.deltaTime);
        }

        if (CameraShake == true && Huricane == true)
        {
            //CameraShaker.Instance.StartShake(RandomShakeM * 2f, RandomShakeR * 4f, 1f * Time.deltaTime);
        }
    }
    
    public void ShopMenu()
    {
        if (Shop == false)
        {
            Shop = true;
        }
        else if(Shop == true)
        {
            Shop = false;
        }
    }
}
