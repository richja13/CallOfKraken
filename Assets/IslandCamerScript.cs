using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCamerScript : MonoBehaviour
{
    public float FollowSpeed = 4f;
    public GameObject Target;
    public float Ypos;
    public float Y;
    public Vector2 BossCamera;
    public bool BossFight;
    public float CameraSize;

    // Start is called before the first frame update
    void Start()
    {
      Ypos = Target.transform.position.y + 0.1f;
      Y = 0.2f;
    }


    void Update()
    {
        //Screen.SetResolution(850, 425, true);
        Screen.SetResolution(1200,600, true);
        
        Application.targetFrameRate = 35;

        Vector3 newPosition = new Vector3(Target.transform.position.x, Y, -10);   

      //  Vector3 newPosition = new Vector3(Target.transform.position.x, Target.transform.position.y + 0.3f, -10);        
    
        //newPosition.y = Target.transform.position.y + 0.5f;

        if (Target.transform.eulerAngles.y == 180)
        {
            newPosition.x = Target.transform.position.x - 0.3f;
        }
        else
        {
            newPosition.x = Target.transform.position.x + 0.3f;
        }
        if(!BossFight)
        {
          transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = BossCamera;//Vector3.Slerp(transform.localPosition,BossCamera, FollowSpeed * Time.deltaTime * 1.2f);
            this.gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(1,CameraSize,60f);
        }
    }
}
