using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement variables")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Animator animator;

    private bool isGrounded;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded =  Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
        }
    }
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if (Mathf.Abs(direction) > 0.01f && !animator.GetBool("isAttacking"))
        {
            HorizontalMovement(direction);

            if (isGrounded)
            {
                animator.SetBool("isRunning", true);
            }

            if (direction < -0.01f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (direction > 0.01f)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(animationCurve.Evaluate(direction) * speed, rb.velocity.y);
    }
}
