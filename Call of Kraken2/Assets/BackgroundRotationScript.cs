using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotationScript : MonoBehaviour
{
    public CameraFollowScript follow;

    void Start()
    {
        
    }

     void Update()
    {
        transform.eulerAngles = follow.GetComponent<Transform>().eulerAngles;
    }
}
