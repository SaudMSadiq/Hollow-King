using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;

    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.UpdateHealth(health, maxHealth);

        Debug.Log("Player health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}