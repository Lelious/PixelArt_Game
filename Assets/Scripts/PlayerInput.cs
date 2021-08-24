using UnityEngine;
[RequireComponent(typeof(Shooter))]

public class PlayerInput : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private Shooter shooter;
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_2))
        {
            shooter.Shoot();
        }

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            animator.SetBool("isAttacking", true);
        }

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
