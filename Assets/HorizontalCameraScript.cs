using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCameraScript : MonoBehaviour
{
    public GameObject Target;
    public bool OnBossArea;
    public Vector3 BossRoom;
    public bool BossDeath;
    private float RandomShakeX;
    private float RandomShakeY;

    // Start is called before the first frame update
    void Start()
    {
        BossDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       // Application.targetFrameRate = 30;
       if(OnBossArea == false)
       {
            Vector3 newPosition = new Vector3(0, Target.transform.position.y, -10);
            transform.position = newPosition;
       }
       else
       {
           transform.position = new Vector3(BossRoom.x,BossRoom.y, BossRoom.z);  
           //Vector3.Slerp(transform.position, BossRoom, 0.2f);  
       }   

        if(BossDeath)
        {
            RandomShakeY = Random.Range(-0.05f,0.05f);
            RandomShakeX = Random.Range(-0.05f,0.05f);
            var CameraShaking = new Vector3(BossRoom.x+RandomShakeX,BossRoom.y+RandomShakeY, -10);
            transform.position = CameraShaking;
        }


    }

    
}
