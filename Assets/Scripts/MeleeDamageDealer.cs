using UnityEngine;

public class MeleeDamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            if (collision.gameObject.name.Equals("Skeleton"))
            {
                collision.gameObject.GetComponent<SkeletonController>().Hit();
            }
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossStats>().TakeDamage(_damage);
        }
    }
}
