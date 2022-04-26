using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownSoundsScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public AudioSource Wind;
    public GameObject Seagulls;
    int iRandom;
    public bool CanSpawnSeagull;
    void Start()
    {
        CanSpawnSeagull = true;
        //Seagulls.Play(1);
    }

    // Update is called once per frame
    void Update()
    {
        iRandom = Random.Range(1,50);

        if(iRandom == 4 && CanSpawnSeagull)
        {
            Instantiate(Seagulls);
            CanSpawnSeagull = false;
        }
    }
     
 

}
