using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerDoubleJump doubleJump = other.GetComponent<PlayerDoubleJump>();
        if (doubleJump != null)
        {
            doubleJump.UnlockDoubleJump();
        }

        Destroy(gameObject);
    }
}