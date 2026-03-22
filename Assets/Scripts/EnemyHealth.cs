using UnityEngine;

public class EnemyHealth : MonoBehaviour
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

        Debug.Log("Enemy health: " + health);

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