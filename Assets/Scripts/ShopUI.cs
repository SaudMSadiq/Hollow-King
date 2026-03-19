using UnityEngine;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI goldText;

    public Player player;

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

    public void BuyItem(int itemIndex, int price)
    {
        if (player.gold >= price)
        {
            player.gold -= price;
            player.ownedItems[itemIndex] = true;
            UpdateGoldText();

            Debug.Log("Bought: " + itemIndex);
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    public void UpdateGoldText()
    {
        goldText.text = player.gold.ToString();
    }
}