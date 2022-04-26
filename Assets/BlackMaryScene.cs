using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMaryScene : MonoBehaviour
{
    public Animator CamPosAnim;
    public Camera mainCam;
    public GameObject CameraTarget;
    public IslandCamerScript Isl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(ProjectMaster.IActMissionNumber == 40)
            {
                ProjectMaster.IActMissionNumber = 41;
            }

            Isl.Target = CameraTarget;
            mainCam.orthographicSize = 1.32f;
            CamPosAnim.SetTrigger("Camera");
        }
    }
}
