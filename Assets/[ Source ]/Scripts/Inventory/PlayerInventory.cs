using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    [HideInInspector] public int CurrentMoney {  get; private set; }

    public Dictionary<ItemData, InventoryItem> itemsDictionary = new Dictionary<ItemData, InventoryItem>();
    public event Action ItemsChanged;

    public static PlayerInventory Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        CurrentMoney = startMoney;
    }

    public void PurchaseItem(ItemData itemData)
    {
        if (itemsDictionary.TryGetValue(itemData, out InventoryItem item)) return;
        if (CurrentMoney - itemData.Price < 0) return;

        CurrentMoney -= itemData.Price;
        AddItem(itemData);
    }
    public void AddItem(ItemData itemData)
    {    
       InventoryItem newItem = new InventoryItem(itemData);
       itemsDictionary.Add(itemData, newItem);
       
       ItemsChanged?.Invoke();
    }

    public void SellItem(ItemData itemData)
    {
        if (!itemsDictionary.TryGetValue(itemData, out InventoryItem item)) return;

        CurrentMoney += itemData.Price;
        RemoveItem(itemData);
    }
    public void RemoveItem(ItemData itemData)
    {
        if (itemsDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            itemsDictionary.Remove(itemData);
            ItemsChanged?.Invoke();
        }
    }
} 
