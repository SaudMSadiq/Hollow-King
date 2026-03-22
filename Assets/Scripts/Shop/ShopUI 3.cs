using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI goldText;

    public Player player;
    public Inventory inventory;

    private void Start()
    {
        CloseShop();
    }

    public void ToggleShop()
    {
        if (shopPanel.activeSelf)
        {
            CloseShop();
        }
        else
        {
            OpenShop();
        }
    }
    
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        UpdateGoldText();
        Time.timeScale = 0f;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BuyItem(string itemName, int price)
    {
        if (player.gold >= price)
        {
            player.gold -= price;
            UpdateGoldText();
            inventory.AddItem(itemName);

            Debug.Log("Bought " + itemName);
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void BuyPotion()
    {
        BuyItem("Potion", 25);
    }
    
    public void BuyDamage()
    {
        BuyItem("Damage", 50);
    }

    public void BuyHealth()
    {
        BuyItem("Health", 50);
    }

    private void UpdateGoldText()
    {
        goldText.text = player.gold.ToString();
    }
    
}