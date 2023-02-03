using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UIInventory uiInventory;
    
    private bool isStop = false;
    public bool IsPlayerStop => isStop;
    private void Awake() {
        // inventory = new Inventory();
        // uiInventory.SetInventory(inventory);

        // ItemAtWorld.SpawnNewItem(new Vector3(-25,-25,32), new Item{itemType = Item.ItemType.Feather, amount = 1});
    }
}
