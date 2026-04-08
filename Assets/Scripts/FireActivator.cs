using UnityEngine;

public class FireActivator : MonoBehaviour
{
    public GameObject fireGroup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fireGroup.SetActive(true);
        }
    }
}