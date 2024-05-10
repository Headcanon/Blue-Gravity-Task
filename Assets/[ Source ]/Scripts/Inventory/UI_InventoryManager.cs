using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryManager : MonoBehaviour
{
    private List<UI_InventorySlot> inventorySlots;

    private void Start()
    {
        PlayerInventory.Instance.ItemsChanged += DrawItems;

        inventorySlots = new List<UI_InventorySlot>();
        inventorySlots.AddRange(GetComponentsInChildren<UI_InventorySlot>());

        DrawItems();
    }

    private void OnEnable()
    {
        if(inventorySlots != null) DrawItems();
    }

    private void DrawItems()
    {
        ResetItems();

        int i = 0;
        foreach (ItemData item in PlayerInventory.Instance.itemsDictionary.Keys)
        {
            inventorySlots[i].SetItem(item);
            i++;
        }
    }

    private void ResetItems()
    {
        foreach(UI_InventorySlot slot in inventorySlots)
        {
            slot.SetItem(null);
        }
    }
}
