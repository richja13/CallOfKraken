using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationScript : MonoBehaviour
{
    private float rot;
    public GameObject Platform1;
    public GameObject Platform2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Platform1.transform.eulerAngles = new Vector3(0,0,0);
        Platform2.transform.eulerAngles = new Vector3(0,0,0);
      
        
            rot += 0.6f;
     
        transform.eulerAngles = new Vector3(0, 0, rot);
    }



}
