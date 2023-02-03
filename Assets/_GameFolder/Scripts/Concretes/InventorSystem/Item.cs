using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Feather,
        Skin, 
        FishScale
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Feather: return ItemManager.Instance.feather;
            case ItemType.Skin: return ItemManager.Instance.skin;
            case ItemType.FishScale: return ItemManager.Instance.fishScale;
        }
    }
    
}
