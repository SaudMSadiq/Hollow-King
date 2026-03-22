using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 3f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private int attackCombo = 0;
    private float attackTimer = 2f;
    private float attackCooldown = 0.5f;
    private bool isAttacking = false;
    private bool isBlocking = false;
    private bool isHurt = false;
    private bool isDead = false;

    public int gold = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        float moveInput = Input.GetAxis("Horizontal");

        // Movement (block during attack)
        if (!isAttacking && !isBlocking)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }

        // Jump
        if (Input.GetKey(KeyCode.W) && isGrounded && !isBlocking)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // Running
        if (Mathf.Abs(moveInput) > 0 && !isAttacking)
            animator.SetInteger("AnimState", 1);
        else if (!isAttacking)
            animator.SetInteger("AnimState", 0);

        // Flip direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Attack combo
        if (Input.GetMouseButtonDown(0) && !isHurt)
        {
            attackTimer = attackCooldown;
            attackCombo++;
            if (attackCombo > 3) attackCombo = 1;
            isAttacking = true;

            if (attackCombo == 1) animator.SetTrigger("Attack1");
            else if (attackCombo == 2) animator.SetTrigger("Attack2");
            else if (attackCombo == 3)
            {
                animator.SetTrigger("Attack3");
                attackCombo = 0;
            }
        }

        // Attack timer reset
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                isAttacking = false;
                attackCombo = 0;
            }
        }

        // Block
        if (Input.GetMouseButton(1)) 
        {
            animator.SetBool("Block", true);
            isBlocking = true;
        }else 
        {
            animator.SetBool("Block", false);
            isBlocking = false;
        }


        // Roll
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
            animator.SetTrigger("Roll");
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("Grounded", isGrounded);
    }

    // Call this from enemy scripts to trigger hurt
    public void TakeHit()
    {
        if (isDead) return;
        isHurt = true;
        animator.SetTrigger("Hurt");
    }

    private void RecoverFromHurt()
    {
        isHurt = false;
    }

    // Call this to kill the player
    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Death");
    }

    public void addCoin()
    {
        
    }
}
