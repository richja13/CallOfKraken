using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   public Transform itemSlotContainer;
   private Transform itemSlotTemplate;
   

    public void Update()
    {
        
     
    
    }

    public void Awake()
    {
       // itemSlotContainer = transform.Find("ItemSlot");
        itemSlotTemplate = itemSlotContainer.Find("Slot");
    }

   public void SetInventory(Inventory inventory)
   {
       this.inventory = inventory;
       RefreshInventoryItems();
       inventory.OnItemListChanged += Inventory_OnItemListChanged;
   }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }
   private void RefreshInventoryItems()
   {
        foreach(Transform child in itemSlotContainer)
        {
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        
       float x = -25.1f;
       float y = 124.8f;
       float itemSlotCellSize = 1f;
       foreach (Item item in inventory.GetItemList())
       {
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y );
           x = x + 124.4f;
          if(x > 575)
          {
              x = -25.1f;
              y = y - 112.3f;
          }

          Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
          image.sprite = item.GetSprite();
       }
   
   }
}
