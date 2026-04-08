using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public bool isGrounded;
    public Animator animator;
    public int attackCombo = 0;
    public float attackTimer = 2f;
    public float attackCooldown = 0.5f;
    public bool isAttacking = false;
    public bool isBlocking = false;
    public bool isHurt = false;
    public bool isDead = false;
    public int gold = 0;
    
    public int maxJumps = 1;
    private int jumpsRemaining;
    private bool wasGrounded;
    
    public bool groundPoundUnlocked = false;
    public float groundPoundSpeed = -20f;
    public Transform poundPoint;
    public float poundRadius = 1.5f;
    private bool isGroundPounding;
    
    public static Player Instance;
    
    public Light2D playerLight;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        jumpsRemaining = maxJumps;
    }
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Layer 4")
            playerLight.enabled = true;
        else
            playerLight.enabled = false;
        
        if (isDead) return;
        float moveInput = Input.GetAxis("Horizontal");
        if (!isAttacking && !isBlocking)
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0 && !isBlocking)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsRemaining--;
            animator.SetBool("Jump", true);
        }

        animator.SetBool("Jump", !isGrounded);
        
        if (Mathf.Abs(moveInput) > 0 && !isAttacking)
            animator.SetInteger("AnimState", 1);
        else if (!isAttacking)
            animator.SetInteger("AnimState", 0);
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetMouseButtonDown(0) && !isHurt && !isBlocking)
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
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                isAttacking = false;
                attackCombo = 0;
            }
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("Block", true);
            isBlocking = true;
        }
        else
        {
            animator.SetBool("Block", false);
            isBlocking = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
            animator.SetTrigger("Roll");

        if (groundPoundUnlocked)
        {
            // check ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // start ground pound
            if (!isGrounded && Input.GetKeyDown(KeyCode.S) && !isGroundPounding)
            {
                isGroundPounding = true;
            }

            // force downward
            if (isGroundPounding)
            {
                rb.linearVelocity = new Vector2(0f, groundPoundSpeed);
            }

            // landing
            if (isGroundPounding && isGrounded)
            {
                isGroundPounding = false;

                // destroy nearby objects
                Collider2D[] hits = Physics2D.OverlapCircleAll(poundPoint.position, poundRadius);

                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("Breakable"))
                    {
                        Destroy(hit.gameObject);
                    }
                }
            }
        }

    }
    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("Grounded", isGrounded);
        
        if (isGrounded && !wasGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        wasGrounded = isGrounded;
    }
    public void Die()
    {
        if (isDead) return;
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        animator.SetTrigger("Death");
        StartCoroutine(ReloadAfterDeath());
    }
    public IEnumerator ReloadAfterDeath()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            yield return null;
        float deathLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(deathLength);

        Instance = null;
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}