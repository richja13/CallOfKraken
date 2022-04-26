using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;
    public GameObject StartPosY;


    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //StartPosY = transform.position.y;
      
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + distance, StartPosY.transform.position.y, transform.position.z);
        //transform.position = new Vector3(startpos + distance, StartPosY, transform.position.z);

        transform.localRotation = new Quaternion(0, 0, 0, 1); 
  
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }


}
