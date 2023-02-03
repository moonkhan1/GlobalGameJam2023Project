using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> ItemList;

    public Inventory()
    {
        ItemList = new List<Item>();
        Debug.Log("Here!");
        AddItem(new Item{itemType = Item.ItemType.Skin, amount = 1});
        AddItem(new Item{itemType = Item.ItemType.FishScale, amount = 1});
        AddItem(new Item{itemType = Item.ItemType.Feather, amount = 1});
    }

    public void AddItem(Item item)
    {
        ItemList.Add(item);
    }

    public List<Item> GetListItems()
    {
        return ItemList;
    }


}
