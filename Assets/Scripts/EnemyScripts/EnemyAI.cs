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

    private Transform player;
    private float nextAttackTime = 0f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
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
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= startPosition.x - patrolDistance)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void AttackPlayer()
    {
        FacePlayer();

        if (Time.time >= nextAttackTime)
        {
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

        if (player.position.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}