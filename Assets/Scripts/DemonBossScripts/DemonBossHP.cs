using UnityEngine;

public class DemonBossHP : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;

    public HealthBar healthBar;
    private Animator animator;

     void Start()
    {
       animator = GetComponent<Animator>(); 
       healthBar.UpdateHealth(health, maxHealth); 
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Efucking help me");
        animator.SetTrigger("Hurt");
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
        //animator.SetTrigger("Death");
        Destroy(gameObject);
    }
}
