using UnityEngine;
using System.Collections;

public class DemonBossHealth : EnemyHealth
{
    private Animator animator;
    private int damageCounter = 0;
    public bool isAlive = true;

    protected override void Start()
    {
        animator = GetComponent<Animator>(); 
        base.Start();
    }

    public override void TakeDamage(int damage)
    {   
        if (damageCounter == 7)
        {
            animator.SetTrigger("Hurt");
            damageCounter = 0;
        }
        base.TakeDamage(damage);
        damageCounter++;
    }

    protected override void Die()
    {
        isAlive = false;
        animator.SetTrigger("Death");
        StartCoroutine(DieWithDelay());
    }

    private IEnumerator DieWithDelay()
    {
        yield return new WaitForSeconds(4f);
        base.Die();
    }
}
