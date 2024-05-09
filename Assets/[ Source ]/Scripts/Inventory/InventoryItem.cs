using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData ItemData;
    public InventoryItem(ItemData itemData)
    {
        ItemData = itemData;
    }
}
