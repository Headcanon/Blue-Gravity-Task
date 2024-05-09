using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<ItemData, InventoryItem> itemsDictionary = new Dictionary<ItemData, InventoryItem>(); 

    public void AddItem(ItemData itemData)
    {
        if (!itemsDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            InventoryItem newItem = new InventoryItem(itemData);
            itemsDictionary.Add(itemData, newItem);
        }

        foreach(ItemData i in itemsDictionary.Keys)
        {
            print(i.displayName);
        }
    }

    public void RemoveItem(ItemData itemData)
    {
        if (itemsDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            itemsDictionary.Remove(itemData);
        }
    }
} 
