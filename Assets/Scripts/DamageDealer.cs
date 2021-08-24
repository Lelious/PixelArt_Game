using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem particleExplosion;
    private SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            Instantiate(particleExplosion, collision.transform);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossStats>().TakeDamage(_damage);
            Destroy(gameObject);
        }       
    }

    private void FixedUpdate()
    {
        if (!spriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
