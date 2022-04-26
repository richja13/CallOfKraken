using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Jacket,
        belt,
        hat,
        shoes,
        Sword,
        Gun,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            return ItemAssets.Instance.swordSprite;
       
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.Gun: return ItemAssets.Instance.GunSprite;
            case ItemType.Jacket: return ItemAssets.Instance.JacketSprite;
            case ItemType.belt: return ItemAssets.Instance.BeltSprite;
            case ItemType.shoes: return ItemAssets.Instance.ShoesSprite;
            case ItemType.hat: return ItemAssets.Instance.HatSprite;
            
        }
    }
}
