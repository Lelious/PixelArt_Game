using System.Collections;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        yield return  new WaitForSeconds(5f);
        animator.SetBool("isAttack", true);
    }

    private void CancelEnemyAttack()
    {
        animator.SetBool("isAttack", false);
    }
}
