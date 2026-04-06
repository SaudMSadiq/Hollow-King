using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class DemonBossHealth : EnemyHealth
{
    private Animator animator;
    private int damageCounter = 0;
    public bool isAlive = true;
    //public bool isHurt = false;

    private DemonBossAI demonBossAI;
    private EndScreenManager endScreenManager;

    protected override void Start()
    {
        animator = GetComponent<Animator>(); 
        demonBossAI = GetComponent<DemonBossAI>();
        endScreenManager = FindObjectOfType<EndScreenManager>(true);
        
        base.Start();
    }

    public override void TakeDamage(int damage)
    {   
        /**if (damageCounter == 3)
        {
            animator.SetTrigger("Hurt");
            damageCounter = 0;

            //boss cant do anything when hurt
            isHurt = true;
            StartCoroutine(HurtTrigger());
            isHurt = false;
        }**/
        base.TakeDamage(damage);
        damageCounter++;
    }

    protected override void Die()
    {
        gameObject.layer = LayerMask.NameToLayer("Default"); // Change layer to Default to prevent further interactions
        demonBossAI.attackDamage = 0; // Boss can no longer deal damage

        // Play death animation and disable boss interactions 
        isAlive = false;
        animator.SetTrigger("Death");

        // Start a coroutine to delay the actual destruction of the boss until after the death animation has played
        StartCoroutine(DieWithDelay());
    }

    private IEnumerator DieWithDelay()
    {
        yield return new WaitForSeconds(3.8f);
        base.Die();
        endScreenManager.GameEnd();
    }
}
