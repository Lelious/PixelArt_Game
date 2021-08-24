using UnityEngine;

public class SkeletonAttackBox : MonoBehaviour
{
    [SerializeField] private GameObject _attackBox;
    [SerializeField] private Transform _attackPoint;
    private GameObject currentAttack;
    public void SkeletonAttack()
    {
        currentAttack = Instantiate(_attackBox, _attackPoint.position, Quaternion.identity);       
    }

    public void DeleteSkeletonAttackBox()
    {
        Destroy(currentAttack);
    }

}
