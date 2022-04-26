using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;   
    }

    void StartCollision()
    {
          this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;   
    }
}
