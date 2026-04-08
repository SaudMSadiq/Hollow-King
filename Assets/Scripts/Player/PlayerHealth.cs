using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;
    public HealthBar healthBar;
    private bool isDead = false;
    private Player player;

    void Start()
    {
        health = maxHealth;
        player = GetComponent<Player>();
        if (healthBar != null)
            healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        if (player != null && player.isBlocking)
        {
            Debug.Log("Attack blocked!");
            return;
        }

        health -= damage;
        Debug.Log("Player health: " + health);
        if (healthBar != null)
            healthBar.UpdateHealth(health, maxHealth);

        if (health <= 0)
        {
            isDead = true;
            player.Die();
        }
    }
}