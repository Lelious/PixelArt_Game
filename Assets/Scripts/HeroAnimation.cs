using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Animator anim;
    private bool _isAttacking;

    public void Attack()
    {
        anim.SetBool("isRunning", false);      
        _isAttacking = anim.GetBool("isAttacking");

        if (_isAttacking != true)
        {
            anim.SetBool("isAttacking", true);
        }
    }

    private void Run()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", true);
    }

    public void Death()
    {
        anim.SetBool("isDead", true);
        GetComponent<PlayerInput>().enabled = false;
        deathScreen.SetActive(true);
    }
}
