using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaterSpawner : MonoBehaviour
{
    public GameObject Tile;
    public List<Transform> WaterTilesOnMap;
    private float randomSpawn;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawn = Random.Range(0.1f,0.5f);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Water"))
        {
            WaterTilesOnMap.Add(go.GetComponent<Transform>());
        }

        WaterTilesOnMap = WaterTilesOnMap.Distinct().ToList();

    

        if (WaterTilesOnMap.Count < 2.5)
        {
            Invoke("SpawnRandom", randomSpawn);
           //SpawnRandom();
        }
    }


    public void SpawnRandom()
    {

            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(Tile, screenPosition, Quaternion.identity);
        
    }


}
