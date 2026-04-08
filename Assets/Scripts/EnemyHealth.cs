using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 3;
    public HealthBar healthBar;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        healthBar.UpdateHealth(health, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        healthBar.UpdateHealth(health, maxHealth);
        Debug.Log("Enemy health: " + health);

        if (health <= 0)
            Die();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;

        if (animator != null)
            animator.SetTrigger("Die");

        Destroy(gameObject, 1.2f);
    }
}