using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public int attackDamage = 1;
    public float attackCooldown = 1.5f;

    [Header("Sprite Settings")]
    public bool flippedByDefault = false;

    private Transform player;
    private float nextAttackTime = 0f;
    private Vector3 startPosition;
    private bool movingRight = true;
    private Animator animator;

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        FaceDirection(movingRight);
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
                return;
            }
        }
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + patrolDistance)
            {
                movingRight = false;
                FaceDirection(movingRight);
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPosition.x - patrolDistance)
            {
                movingRight = true;
                FaceDirection(movingRight);
            }
        }
    }

    void AttackPlayer()
    {
        FacePlayer();

        if (Time.time >= nextAttackTime)
        {
            if (animator != null)
                animator.SetTrigger("Attack");

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy attacked player!");
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void FacePlayer()
    {
        if (player == null) return;
        Vector3 scale = transform.localScale;
        bool facingRight = player.position.x > transform.position.x;
        if (flippedByDefault) facingRight = !facingRight;
        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void FaceDirection(bool right)
    {
        Vector3 scale = transform.localScale;
        bool faceRight = flippedByDefault ? !right : right;
        scale.x = faceRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}