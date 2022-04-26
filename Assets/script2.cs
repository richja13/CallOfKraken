using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2 : MonoBehaviour
{
    public IslandCamerScript CamScript;
    public GameObject CamPosition;
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
            CamScript.Y = CamPosition.transform.position.y;
            CamScript.Target = CamPosition;

        }
    }
}
