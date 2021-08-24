using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBourneAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private enum State { HeroIdleNightBourneBlink, NightBourneCasting, NightBourneHit, NightBourneIdle, NightBourneShootWawe, NightBourneWalk, NightBourneDeath }
    private State state = State.NightBourneIdle;
    private Rigidbody2D rigidbody;   

    public void Hit()
    {
        animator.Play("NightBourneHit");
        rigidbody.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SkeletonStopper"))
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
    private void EndHit()
    {
        animator.SetBool("Hit", false);
    }
}
