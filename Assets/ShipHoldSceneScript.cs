using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHoldSceneScript : MonoBehaviour
{
    public GameObject Doors;
    public GameObject Key;
    public ParticleSystem DoorParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Key.activeSelf)
        {
            Doors.GetComponent<DoorOpening>().enabled = true;
        }
        else
        {
            Doors.GetComponent<DoorOpening>().enabled = false;
        }
    }
}
