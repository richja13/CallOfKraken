using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaScript : MonoBehaviour
{
    public MichaelScript Skrypt;
    public PlayerStatsScript Stats;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
         Skrypt = this.gameObject.GetComponent<MichaelScript>();
        Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsScript>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!Skrypt.StillAlive && Skrypt.HP <= 0)
       {
           Stats.SpawnFirstKey();
           Skrypt = null;
           ProjectMaster.IActMissionNumber = 18;
       }
    }
}
