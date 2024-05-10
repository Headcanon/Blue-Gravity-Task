using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI_MoneyUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        PlayerInventory.Instance.ItemsChanged += UpdateText;
    }

    private void UpdateText()
    {
        textMesh.text = "$" + PlayerInventory.Instance.CurrentMoney;
    }
}
