using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI goldText;

    public Player player;
    public Inventory inventory;

    public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;

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
        UpdateGoldText();
        shopPanel.SetActive(true);
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
            //inventory.AddItem(itemName); //to add back later with inventory, just testing

            Debug.Log("Bought " + itemName);
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void BuyPotion()
    {
        if (playerHealth.health >= playerHealth.maxHealth)
        {
            return;
        }
        BuyItem("Potion", 10);
        playerHealth.health++;
        playerHealth.healthBar.UpdateHealth(playerHealth.health, playerHealth.maxHealth);
    }
    
    public void BuyDamage()
    {
        BuyItem("Damage", 25);
        playerAttack.attackDamage++;
    }

    public void BuyHealth()
    {
        BuyItem("Health", 25);
        playerHealth.maxHealth++;
        playerHealth.healthBar.UpdateHealth(playerHealth.health, playerHealth.maxHealth);
    }

    private void UpdateGoldText()
    {
        goldText.text = player.gold.ToString();
    }
    
}