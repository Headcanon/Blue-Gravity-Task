using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

enum SlotType { PurchasableSlot, EquipableSlot, SellableSlot }
public class UI_InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemData currentItemData;
    [SerializeField] private SlotType slotType;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private TextMeshProUGUI priceTextMesh;
    private Image itemIcon;

    private void Awake()
    {
        itemIcon = GetComponent<Image>();
        SetItem(currentItemData);
    }

    public void SetItem(ItemData newItemData)
    {
        if (newItemData == null) itemIcon.sprite = emptySprite;
        else
        {
            currentItemData = newItemData;
            itemIcon.sprite = currentItemData.Icon;
            if(priceTextMesh != null ) 
                priceTextMesh.text = "$" + newItemData.Price;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (slotType)
        {
            case SlotType.PurchasableSlot: BuyItem(); break;
            case SlotType.EquipableSlot: EquipItem(); break;
            case SlotType.SellableSlot: SellItem(); break;
        }
    }

    private void SellItem()
    {
        PlayerInventory.Instance.SellItem(currentItemData);
    }

    private void EquipItem()
    {
        AnimatorController.ChangeClothes(currentItemData);
    }

    private void BuyItem()
    {
        PlayerInventory.Instance.PurchaseItem(currentItemData);
    }
}
