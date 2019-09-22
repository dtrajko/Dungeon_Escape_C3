﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    public int currentSelectedItem;
    public int currentItemCost;
    public string currentSelectedItemName;

    private Player _player;

    private void Start() {
        shopPanel.SetActive(false);
        _player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            _player = other.GetComponent<Player>();
            if (_player != null) {
                UIManager.Instance.OpenShop(_player.Diamonds);
            }
            shopPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int index) {
        switch (index) {
            case 0:
                currentSelectedItemName = "Flame Sword";
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                currentSelectedItemName = "Boots of Flight";
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                currentSelectedItemName = "Key to Castle";
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
        // Debug.Log("Selected Item: " + "[" + index + "] " + itemName);
        UIManager.Instance.UpdateShopSelection(index);
    }

    public void BuyItem()
    {
        if (_player.Diamonds >= currentItemCost)
        {
            // Award item
            _player.Diamonds -= currentItemCost;
            Debug.Log("Purchased Item: " + " [" + currentSelectedItem + "] " + currentSelectedItemName);
            Debug.Log("Remaining gems: " + _player.Diamonds);
            // UIManager.Instance.OpenShop(_player.Diamonds);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You do not have enough gems. Closing shop.");
            shopPanel.SetActive(false);
        }
    }
}
