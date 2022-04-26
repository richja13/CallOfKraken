using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToShipScript : MonoBehaviour
{
    public void BackToShip()
    {
       

        SceneManager.LoadScene("topDown");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(ProjectMaster.IActMissionNumber == 4)
        {
            ProjectMaster.IActMissionNumber = 5;
        }

        if(ProjectMaster.IActMissionNumber == 20)
        {
            ProjectMaster.IActMissionNumber = 21;
        }
        
        if(ProjectMaster.IActMissionNumber == 26)
        {
            ProjectMaster.IActMissionNumber = 27;
        }

        if(ProjectMaster.IActMissionNumber == 36)
        {
            ProjectMaster.IActMissionNumber = 37;
        }

        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("topDown");
        }
    }

}
