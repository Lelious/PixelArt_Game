using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody;
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private float currentState, currentTimeToRevert;
    private void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;           
        }
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rigidbody.velocity = Vector2.right * speed;
                break;
            case REVERT_STATE:
                spriteRenderer.flipX = !spriteRenderer.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                timeToRevert = Random.Range(2, 7);
                break;
        }
        animator.SetFloat("Velocity", rigidbody.velocity.magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SkeletonStopper"))
        {
            rigidbody.velocity = Vector2.zero;
            currentState = IDLE_STATE;
        }
    }

    public void Hit()
    {
        animator.Play("SkeletonHit");
        rigidbody.velocity = Vector2.zero;
    }

    private void EndHit()
    {
        animator.SetBool("Hit", false);
    }
}
