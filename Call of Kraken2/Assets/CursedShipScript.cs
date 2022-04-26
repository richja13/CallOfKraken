using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedShipScript : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyShip Script;
    public GameObject Island;
    void Start()
    {
        Script = this.gameObject.GetComponent<EnemyShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Script.Abord)
        {
            if(ProjectMaster.IActMissionNumber == 43)
            {
                ProjectMaster.IActMissionNumber = 44;
            }
            Script.enabled = false;
            MoveToIsland();
        }
    }

    void MoveToIsland()
    {
        transform.position = Vector2.Lerp(transform.position, Island.transform.position, 0.04f * Time.deltaTime);
    }
}
