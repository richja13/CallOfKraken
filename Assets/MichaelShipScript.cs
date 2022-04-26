using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelShipScript : MonoBehaviour
{
    EnemyShip MainScript;
    void Start()
    {
        MainScript = this.gameObject.GetComponent<EnemyShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ProjectMaster.IActMissionNumber == 6 && MainScript.Abord == true)
        {
            ProjectMaster.IActMissionNumber = 7;
        }
    }
}
