using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    private void Start() {
        // shopPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if (player != null) {
                UIManager.Instance.OpenShop(player.Diamonds);
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
        string itemName = "";
        switch (index) {
            case 0:
                itemName = "Flame Sword";
                break;
            case 1:
                itemName = "Boots of Flight";
                break;
            case 2:
                itemName = "Key to Castle";
                break;
        }
        // Debug.Log("Selected Item: " + "[" + index + "] " + itemName);
        UIManager.Instance.UpdateShopSelection(index);
    }
}
