using UnityEngine;

public class DemonBossHP : EnemyHealth
{
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("please work");
        base.TakeDamage(damage);
 
        Debug.Log("Boss health: " + health);
 
        //animator.SetTrigger("BossHurt");
 
        if (health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        //animator.SetBool("BossDeath", true);
        base.Die();
    }
}
