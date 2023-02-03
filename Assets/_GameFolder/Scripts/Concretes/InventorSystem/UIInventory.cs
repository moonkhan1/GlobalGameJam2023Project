using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private Inventory _inventory;
    private Transform itemContainer;
    private Transform itemImg;
    [SerializeField] GameObject items;


    private void Awake() {
        itemContainer = transform.Find("itemContainer");
        // itemImg = itemContainer.Find("itemImg");
    }
    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSize = 30f;
        foreach (Item item in _inventory.GetListItems())
        {
            RectTransform itemRectTransform = Instantiate(items,itemContainer).GetComponent<RectTransform>();
            itemContainer.gameObject.SetActive(true);
            itemRectTransform.gameObject.SetActive(true);
            itemRectTransform.anchoredPosition = new Vector2(x * itemSize, y * itemSize);
            Image image = itemRectTransform.Find("itemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
        }
    }
}
