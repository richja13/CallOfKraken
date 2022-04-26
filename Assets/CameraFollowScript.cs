using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowScript : MonoBehaviour
{
    public float FollowSpeed = 4f;
    public GameObject Target;
    public float Timer1;
    private bool TimerTrue;
    public Vector2 BossCamera;
    public bool BossFight;
    public float CameraSize;
    // Start is called before the first frame update
    void Start()
    {
        var cameraRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 8);
        transform.rotation = cameraRotation;

    }


    void Update()
    {
       
        //Screen.SetResolution(850,425 , true);
        //Screen.SetResolution(900,450, true);
        Screen.SetResolution(1200,600, true);
        Application.targetFrameRate = 35;

        //Debug.unityLogger.logEnabled = false;

        var CameraShakingR = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 2);
        var CameraShakingL = Quaternion.Euler(transform.rotation.x, transform.rotation.y,-2);

        //Debug.Log(transform.rotation.eulerAngles.z);
    
        if (Timer1 >= 0 && Timer1 < 300)
        {
            Timer1 += 60 * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, CameraShakingL, 0.7f  * Time.deltaTime);
        }
        else if (Timer1 >= 300 && Timer1 < 600)
        {
            Timer1 += 75 * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, CameraShakingR, 0.7f * Time.deltaTime);
        }
        else if (Timer1 >= 600)
        {
            Timer1 = 0;
        }

        //if (transform.eulerAngles.z != -7)
        //{

        //}
        Vector3 newPosition = Target.transform.position;
        newPosition.z = -10;
        if(!BossFight)
        {
            this.gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(CameraSize,1,60f );//* Time.deltaTime);
            if (Target.transform.eulerAngles.y == 180)
            {
                newPosition.x = Target.transform.position.x - 0.3f;
            }
            else
            {
                newPosition.x = Target.transform.position.x + 0.3f;
            }
             transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = BossCamera;//Vector3.Slerp(transform.localPosition,BossCamera, FollowSpeed * Time.deltaTime * 1.2f);
            this.gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(1,CameraSize,60f);
        }
        
       
    }
}
