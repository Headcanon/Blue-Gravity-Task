using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject ButtonIcon;
    [SerializeField] private GameObject Menu;

    private Collider2D Collider;

    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void Interact()
    {
        Menu.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls playerInventory = collision.GetComponent<PlayerControls>();
        if (playerInventory != null)
        {
            ButtonIcon.SetActive(true);
            playerInventory.interactAction += Interact;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerControls playerInventory = collision.GetComponent<PlayerControls>();
        if (playerInventory != null)
        {
            ButtonIcon.SetActive(false);
            playerInventory.interactAction -= Interact;
        }
    }
}
