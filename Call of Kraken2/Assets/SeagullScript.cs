using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Wind;
    void Start()
    {
        Wind = GameObject.FindGameObjectWithTag("Wall");
        Invoke("DestroyObject",20f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        Wind.GetComponent<TopDownSoundsScript>().CanSpawnSeagull = true;
        Destroy(this.gameObject);
    }
}
