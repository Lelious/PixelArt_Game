using UnityEngine;

public class ChangeAttackAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioSource audioSource;

    private void AttackSound()
    {
        audioSource.PlayOneShot(punchSound);
    }
    private void WalkSound()
    {
        audioSource.PlayOneShot(walkSound);
    }
    private void EndWalkSound()
    {
        audioSource.Stop();
    }

    private void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        anim.SetInteger("AttackPose", Random.Range(0, 3));
    }
}
