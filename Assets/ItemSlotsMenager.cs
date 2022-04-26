using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotsMenager : MonoBehaviour
{
  public List<GameObject> SlotList;
  public List<Item> ItemList;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject NewObject in GameObject.FindGameObjectsWithTag("Slot"))
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
      ItemList =  Inventory.itemList ;

    }

    public void AddItemToSlot()
    {
      for(int i = 0; i < SlotList.ToArray().Length;i++)
      {
        if(SlotList[i].GetComponent<ItemSlot>().isEmpty)
        {

          SlotList[i].GetComponent<ItemSlot>().isEmpty = false;
        }
      }
    }
}



