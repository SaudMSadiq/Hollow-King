using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class DemonBossAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float chaseRange = 6f;
    public float attackRange = 3f;

    [Header("Attack")]
    public int attackDamage = 2;
    public float attackCooldown = 2f;

    private Transform player;
    private Animator animator;
    private float nextAttackTime;
    private DemonBossHealth demonBossHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        demonBossHealth = GetComponent<DemonBossHealth>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        animator.SetBool("Walking", false);
    }

    void Update()
    {
        if (!demonBossHealth.isAlive)
        {
            return;
        }   

        float distance = Vector2.Distance(transform.position, player.position);
        FacePlayer();

        if (distance <= attackRange)
        {
            // Stop moving, play idle, then attack
            animator.SetBool("Walking", false);
            Attack();
        }
        else if (distance <= chaseRange)
        {
            // Only chase — Walking bool stays true for the whole frame
            animator.SetBool("Walking", true);
            ChasePlayer();
        }
        else
        {
            // Out of range — idle
            animator.SetBool("Walking", false);
        }
    }

    void ChasePlayer()
    {
        float directionX = player.position.x - transform.position.x;
        Vector3 movement = new Vector3(Mathf.Sign(directionX), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void Attack()
    { 
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");

            StartCoroutine(ApplyDamageWithDelay(1.3f));

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    IEnumerator ApplyDamageWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (demonBossHealth.isAlive)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            //only apply damage if player is still in range
            if (playerHealth != null && Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                playerHealth.TakeDamage(attackDamage); 
            }
        }
    }

   void FacePlayer()
    {
        Vector3 scale = transform.localScale;

        if (player.position.x > transform.position.x)
            scale.x = -Mathf.Abs(scale.x);
        else
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }
}
