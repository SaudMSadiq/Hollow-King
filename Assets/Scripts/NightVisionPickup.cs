using UnityEngine;

public class NightVisionPickup : MonoBehaviour
{
    public GameObject hiddenObjectsParent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Night Vision unlocked!");

            if (hiddenObjectsParent != null)
            {
                hiddenObjectsParent.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}