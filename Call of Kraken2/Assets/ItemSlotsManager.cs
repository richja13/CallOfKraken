using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotsManager : MonoBehaviour
{
    public List<GameObject> SlotList;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject NewObject in GameObject.FindGameObjectsWithTag("slot"))
        {
           SlotList.Add(NewObject);
        }
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
