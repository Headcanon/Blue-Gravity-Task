using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] private string bodyLayer;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private int animationsIndex;

    [HideInInspector] public string BodyLayer { get { return bodyLayer; } } 
    [HideInInspector] public int Price { get { return price; } }
    [HideInInspector] public Sprite Icon { get { return icon; } }
    [HideInInspector] public int AnimationsIndex { get {  return animationsIndex; } }
}
