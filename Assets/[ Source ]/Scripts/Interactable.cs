using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject ButtonIcon;
    [SerializeField] private ItemData item;

    private Collider2D Collider;

    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.AddItem(item);
            ButtonIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ButtonIcon.SetActive(false);
    }
}
