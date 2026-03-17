using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    
    public GameObject interactPrompt;
    public ShopUI shopUI;
    
    private bool playerInRange = false;
    
    void Start()
    {
        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shopUI.OpenShop();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactPrompt != null){
                interactPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactPrompt != null){
                interactPrompt.SetActive(false);
            }
        }
    }
                    
}
