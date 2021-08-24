using UnityEngine;

public class PlayerStateAnimations : MonoBehaviour
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
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float horizontalDirection;
    [SerializeField] private float verticalDirection;
    [SerializeField] private GameObject rightHitCollider;
    [SerializeField] private GameObject leftHitCollider;

    private enum State { HeroIdle, HeroRun, HeroJump, HeroDeath, HeroShoot, HeroFalling, HeroGrounding, HeroAttack1, HeroAttack2, HeroAttack3 }
    private Shooter shooter;
    private State state = State.HeroIdle;
    private State previousState = State.HeroIdle;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private int attackNumber;
    private Health healthAndMana;
    private GameObject activeHitCollider;

    private void Awake()
    {
        activeHitCollider = rightHitCollider;
        healthAndMana = GetComponent<Health>();
        shooter = GetComponent<Shooter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        verticalDirection = rigidBody.velocity.y;

        if (horizontalDirection > 0.01f)
        {
            spriteRenderer.flipX = false;
            activeHitCollider = rightHitCollider;
        }

        if (horizontalDirection < -0.01f)
        {
            spriteRenderer.flipX = true;
            activeHitCollider = leftHitCollider;
        }


        rigidBody.velocity = new Vector2(animationCurve.Evaluate(horizontalDirection) * speed, rigidBody.velocity.y);


        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_2) && state != State.HeroShoot)
        {
            if (healthAndMana.currentMana > 0)
            {
                shooter.Shoot();
                healthAndMana.DecreaseMana();
                SetState(State.HeroShoot);
            }
        }

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1) && state != State.HeroAttack1 && state != State.HeroAttack2 && state != State.HeroAttack3)
        {
            if (isGrounded)
            {
                attackNumber = Random.Range(0, 3);

                switch(attackNumber)
                {
                    case 0:
                        SetState(State.HeroAttack1);
                        break;
                    case 1:
                        SetState(State.HeroAttack2);
                        break;
                    case 2:
                        SetState(State.HeroAttack3);
                        break;
                }
            }
            else
            {
                SetState(State.HeroAttack2);
            }          
        }

        switch (state)
        {
            case State.HeroIdle:               
                if (Mathf.Abs(horizontalDirection) > 0.01 && isGrounded)
                {
                    SetState(State.HeroRun);
                }
                if (Input.GetButtonDown(GlobalStringVars.JUMP))
                {
                    SetState(State.HeroJump);
                    Jump();
                }
                break;
            case State.HeroRun:                

                if (isGrounded)
                {
                    if (Input.GetButtonDown(GlobalStringVars.JUMP))
                    {
                        Jump();
                        SetState(State.HeroJump);
                    }
                }
                else
                {
                    SetState(State.HeroJump);
                }
                if (Mathf.Abs(horizontalDirection) < 0.1f)
                {
                    SetState(State.HeroIdle);
                }
                break;
            case State.HeroJump:
                if (isGrounded)
                {
                    SetState(State.HeroRun);
                }
                if (verticalDirection < 0f && !isGrounded)
                {
                    SetState(State.HeroFalling);
                }
                break;
            case State.HeroFalling:
                if (isGrounded)
                {
                    SetState(State.HeroGrounding);
                }
                break;
            case State.HeroGrounding:
                if (isGrounded)
                {
                    if (Input.GetButtonDown(GlobalStringVars.JUMP))
                    {
                        CancelInvoke("SetStateAfterGrounding");
                        Jump();
                        SetState(State.HeroJump);
                    }
                    else
                    {
                        Invoke("SetStateAfterGrounding", 0.25f);
                    }

                }
                break;
        }
        SetAnimation();
    }

    private void SetAnimation()
    {
        switch(state)
        {
            case State.HeroIdle:
                animator.Play("HeroIdle");
                break;
            case State.HeroRun:
                animator.Play("HeroRun");
                break;
            case State.HeroJump:
                animator.Play("HeroJump");
                break;
            case State.HeroShoot:
                animator.Play("HeroShoot");
                break;
            case State.HeroFalling:
                animator.Play("HeroFalling");
                break;
            case State.HeroGrounding:
                animator.Play("HeroGrounding");
                break;
            case State.HeroAttack1:
                animator.Play("HeroAttack1");
                break;
            case State.HeroAttack2:
                animator.Play("HeroAttack2");
                break;
            case State.HeroAttack3:
                animator.Play("HeroAttack3");
                break;
        }
    }

    private void SetState(State to)
    {
        previousState = state;
        state = to;
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        Invoke("SetStateToJump", 0.1f);
    }

    private void SetStateToJump()
    {
        SetState(State.HeroJump);
    }

    private void SetStateAfterGrounding()
    {
        SetState(State.HeroRun);
    }

    private void SetPreviousState()
    {
        SetState(State.HeroRun);
    }
    private void ActivateAttackCollider()
    {
        activeHitCollider.SetActive(true);
    }
}
