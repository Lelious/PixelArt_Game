using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _firePoint;

    private bool isFlip;
    private float offset = 0.5f;
    private float xVectorOffset = 0.5f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void Shoot()
    {       

        if (spriteRenderer.flipX)
        {
            offset = -1;
            isFlip = true;
            CreateBullet(offset);
        }
        else
        {
            offset = 1;
            isFlip = false;
            CreateBullet(offset);
        }
    }

    private void CreateBullet(float offset)
    {
        GameObject currentBullet = Instantiate(_bullet, _firePoint.position + new Vector3(xVectorOffset * offset, 0, 0), Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletVelocity.velocity = new Vector2(_fireSpeed * offset, currentBulletVelocity.velocity.y);
        _bullet.GetComponent<SpriteRenderer>().flipX = isFlip;
    }
}
