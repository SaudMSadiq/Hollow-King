using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DemonBossAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float chaseRange = 2f;
    public float attackRange = 2f;

    [Header("Attack")]
    public int attackDamage = 1;
    public float attackCooldown = 2f;

    private Transform player;
    private Animator animator;
    private float nextAttackTime;

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Attack();
        }
        else if (distance <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        //animator.SetTrigger("BossIdle");
    }

    void ChasePlayer()
    {
        //animator.SetTrigger("BossWalk");

        float directionX = player.position.x - transform.position.x;

        // Move only on X axis
        Vector3 movement = new Vector3(Mathf.Sign(directionX), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        FacePlayer();
    }
    void Attack()
    {
        FacePlayer();
 
        if (Time.time >= nextAttackTime)
        {
            //animator.SetTrigger("BossAttack");
 
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
 
            nextAttackTime = Time.time + attackCooldown;
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
