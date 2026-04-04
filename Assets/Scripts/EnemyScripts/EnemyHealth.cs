using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;

    public HealthBar healthBar;

    protected virtual void Start()
    {
        healthBar.UpdateHealth(health, maxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.UpdateHealth(health, maxHealth);

        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}