using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private int animationsIndex;

    [HideInInspector] public string DisplayName { get { return displayName; } } 
    [HideInInspector] public int Price { get { return price; } }
    [HideInInspector] public Sprite Icon { get { return icon; } }
    [HideInInspector] public int AnimationsIndex { get {  return animationsIndex; } }
}
