using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMissionScript : MonoBehaviour
{
  public List<GameObject> Sloops;

  void Update()
  {
    if(ProjectMaster.IActMissionNumber < 3)
    {
      if(Sloops[0] == null && Sloops[1] == null && Sloops[2] == null)
      {
        if(ProjectMaster.IActMissionNumber == 2)
        {
          ProjectMaster.IActMissionNumber = 3;
        }
      }
    }
    else
    {
        Destroy(Sloops[0]);
        Destroy(Sloops[1]);
        Destroy(Sloops[2]);
    }
    
  }
}
