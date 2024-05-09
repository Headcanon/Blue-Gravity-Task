using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private List<Image> images;

    private void Start()
    {
        PlayerInventory.Instance.ItemAdded += AddIcon;

        images = new List<Image>();
        images.AddRange(GetComponentsInChildren<Image>());
    }
    private void AddIcon(ItemData itemData)
    {
        int i = 0;
        foreach (ItemData item in PlayerInventory.Instance.itemsDictionary.Keys)
        {
            images[i].sprite = item.Icon;
            i++;
        }
    }
}
