using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnListItemChanged += Inventory_OnItemListChanged;
        RefreshInventorySystem();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventorySystem();
    }

    private void RefreshInventorySystem()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemCellSize = 30f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTrasnfrom = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTrasnfrom.gameObject.SetActive(true);

            itemSlotRectTrasnfrom.anchoredPosition = new Vector2(itemCellSize * x, itemCellSize * y);
            x += 3;
            Image image = itemSlotRectTrasnfrom.Find("image").GetComponent<Image>();
            Image knob = itemSlotRectTrasnfrom.Find("knob").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTrasnfrom.Find("text").GetComponent<TextMeshProUGUI>();

            knob.enabled = false;

            if (item.itemAmount > 1)
            {
                uiText.SetText(item.itemAmount.ToString());
                knob.enabled = true;
            }

            else
            {
                uiText.SetText("");
            }


            if (x > 4)
            {
                x = 0;
                y--;
            }
        }
    }
}