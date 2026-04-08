using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private Animator animator;

    public bool hasDoubleJump = false;

    private int jumpsUsed = 0;
    private bool wasGrounded = false;

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(
            player.groundCheck.position,
            player.groundCheckRadius,
            player.groundLayer
        );

        if (isGrounded)
        {
            jumpsUsed = 0;
        }
        else if (wasGrounded)
        {
            jumpsUsed = 1;
        }

        if (Input.GetKeyDown(KeyCode.W) && !isGrounded && hasDoubleJump && jumpsUsed == 1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, player.jumpForce);
            jumpsUsed = 2;
            animator.SetBool("Jump", true);
        }

        wasGrounded = isGrounded;
    }

    public void UnlockDoubleJump()
    {
        hasDoubleJump = true;
    }
}