using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var newRotation = MainCamera.transform.rotation;
        newRotation.z = MainCamera.transform.rotation.z * 60f;
        //transform.rotation = newRotation;
        
        
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * newRotation.z);
        
    }
    
}
