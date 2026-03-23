using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;

    public HealthBar healthBar;
    private Animator animator;
    private bool isDead = false;

    public LevelCompleteUI levelCompleteUI;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();

        if (healthBar != null)
            healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

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

        if (levelCompleteUI != null)
        {
            levelCompleteUI.ShowLevelComplete();
        }

        StartCoroutine(DestroyAfterDeath());
    }

    IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}