using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI goldText;

    private Player player;
    private Inventory inventory;

    private PlayerAttack playerAttack;
    private PlayerHealth playerHealth;

    private void Start()
    {
        CloseShop();
        player = Player.Instance;

        playerAttack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();
        inventory = player.GetComponent<Inventory>();

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
        Debug.Log("Clicked");
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
        BuyItem("Damage", 50);
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