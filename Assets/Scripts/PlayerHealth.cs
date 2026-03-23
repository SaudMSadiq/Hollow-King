using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;

    public HealthBar healthBar;
    private Animator animator;
    private bool isDead = false;

    private PlayerBlock playerBlock;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        playerBlock = GetComponent<PlayerBlock>();

        if (healthBar != null)
            healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        if (playerBlock != null && playerBlock.isBlocking)
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
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (animator != null)
            animator.SetTrigger("Die");

        StartCoroutine(DestroyAfterDeath());
    }

    IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}