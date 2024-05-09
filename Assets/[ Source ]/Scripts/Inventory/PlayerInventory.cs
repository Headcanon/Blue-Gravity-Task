using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    private int currentMoney;

    public Dictionary<ItemData, InventoryItem> itemsDictionary = new Dictionary<ItemData, InventoryItem>();
    public event Action <ItemData> ItemAdded;

    public static PlayerInventory Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        currentMoney = startMoney;
    }

    public void PurchaseItem(ItemData itemData)
    {
        if (itemsDictionary.TryGetValue(itemData, out InventoryItem item)) return;
        if (currentMoney - itemData.Price < 0) return;

        currentMoney -= itemData.Price;
        print(currentMoney);
        AddItem(itemData);
    }
    public void AddItem(ItemData itemData)
    {    
       InventoryItem newItem = new InventoryItem(itemData);
       itemsDictionary.Add(itemData, newItem);
       
        ItemAdded?.Invoke(itemData);
    }

    public void RemoveItem(ItemData itemData)
    {
        if (itemsDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            itemsDictionary.Remove(itemData);
        }
    }
} 
