using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsSpawnerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject MichaelSloop;
    public GameObject MichaelGaleon;
    public GameObject Skeleton;
    public GameObject SkeletonSloop;
    public GameObject Maynard;
    public GameObject MaynardSloop;
    public GameObject Admiral;
    public GameObject AdmiralSloop;
    
    public float ShipsInAttack;
    public float MaxShips;
    public int RandomFleetSpawn;
    public float MaxSpawnRange;
    public float MinSpawnRange;
    public float MaxRange;
    public static int FleetNumber;
    public GameObject Galeon;
    public GameObject Sloop;
    public int Randomrzecz;
    // Update is called once per frame

    void Start() 
    {
        if( ProjectMaster.IActMissionNumber != 0 && ProjectMaster.IActMissionNumber != 1 && ProjectMaster.IActMissionNumber != 2 && ProjectMaster.IActMissionNumber != 43)
        {
            StartCoroutine(SpawnEnemy());
        }
        Galeon = MichaelGaleon;
        Sloop = MichaelSloop;
    }

    void Update()
    {

        Randomrzecz = FleetNumber;
       // if(FleetNumber == 1)
        //{
           // Sloop = MichaelSloop;
          //  Galeon = MichaelGaleon;
          //  Debug.Log("KRAGEN");
      //  }        
        if( ProjectMaster.IActMissionNumber != 0 && ProjectMaster.IActMissionNumber != 1 && ProjectMaster.IActMissionNumber != 2 && ProjectMaster.IActMissionNumber != 43)
        {
            StartCoroutine(SpawnEnemy());
        
            
        if(ShipsInAttack <= 0)
        {
            Invoke("ChooseFleet",3.5f);
        }
        }

        switch(FleetNumber)
        {
            case 0:
                FleetNumber = 1;
            break;

            case 1:
                Sloop = MichaelSloop;
                Galeon = MichaelGaleon;
            break;

            case 2:
                Sloop = SkeletonSloop;
                Galeon = Skeleton;
            break;

            case 3:
                Sloop = MaynardSloop;
                Galeon = Maynard;
            break;

            case 4:
                Sloop = AdmiralSloop;
                Galeon = Admiral;
            break;
        }



       
    }

    public void ChooseFleet()
    {
        Vector3 center = transform.position;

   

        switch(RandomFleetSpawn)
        {
            case 1:
                if(ShipsInAttack <= 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Vector3 pos = RandomCircle(center, 250.0f);
                        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
                        Instantiate(Galeon, pos,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
                    }
                    ShipsInAttack = 1f;
                }   
            break;

            case 2:
            if(ShipsInAttack <= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 pos = RandomCircle(center, 250.0f);
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
                    Instantiate(Sloop, pos,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
                }

                ShipsInAttack = 1.5f;
            }
            break;
                

            case 3:
            if(ShipsInAttack <= 0)
            {
               
               for (int i = 0; i < 2; i++)
                {
                    Vector3 pos = RandomCircle(center, 250.0f);
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
                    Instantiate(Sloop, pos,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
                }
                Vector3 pos2 = RandomCircle(center, 250.0f);
                //Instantiate(MichaelSloop, pos,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
                Instantiate(Galeon, pos2,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
                ShipsInAttack = 1.5f;
            }

            break;
        }
    }

    IEnumerator SpawnEnemy()
    {
        RandomFleetSpawn = Random.Range(1,3);

        /*Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, 250.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
            Instantiate(prefab, pos,new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z, transform.rotation.w));
        }
        */
        yield return 3.5f;
    }

    public int numObjects = 3;
    public GameObject prefab;
 
    
 
     Vector2 RandomCircle ( Vector2 center ,   float radius)
     {
        float ang = Random.value * 360;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //pos.z = center.z;
        return pos;
    }
}
