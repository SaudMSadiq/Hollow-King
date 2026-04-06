using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 3;
    public int health = 3;

    [Header("References")]
    public HealthBar healthBar;
    public GameObject coinPrefab;

    [Header("Animation")]
    [Tooltip("DarkWolf_2d_Death Animation")]
    public string deathAnimStateName = "Skeleton_Dying";

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
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
        Debug.Log(gameObject.name + " health: " + health);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        GiveGroundPound reward = GetComponentInChildren<GiveGroundPound>();

        if (reward != null)
        {
            reward.GiveReward();
        }
        
        isDead = true;

        if (coinPrefab != null)
            Instantiate(coinPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);

        EnemyAI ai = GetComponent<EnemyAI>();
        if (ai != null) ai.enabled = false;

        EnemyPatrol patrol = GetComponent<EnemyPatrol>();
        if (patrol != null) patrol.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        if (healthBar != null)
            healthBar.gameObject.SetActive(false);
        
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.enabled = false;

        if (animator != null)
        {
            animator.SetTrigger("Death");
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait until the death state is actually playing
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(deathAnimStateName))
            yield return null;

        float deathLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(deathLength);
        Destroy(gameObject);
    }
}