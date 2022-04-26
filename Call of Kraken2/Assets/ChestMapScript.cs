using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMapScript : MonoBehaviour
{
    public GameObject Map;
    public GameObject Gate;
    public GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
            Map.SetActive(true);
            Gate.SetActive(true);
            Arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Map.SetActive(false);
            Gate.SetActive(false);
            Arrow.SetActive(true);
            
            if(ProjectMaster.IActMissionNumber == 25)
            {
                ProjectMaster.IActMissionNumber = 26;
            }
        }
    }
}
