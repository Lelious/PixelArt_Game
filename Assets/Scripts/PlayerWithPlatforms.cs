using UnityEngine;

public class PlayerWithPlatforms : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Parrent")
        {
            rb.velocity = new Vector2(0,0);
        }
    }
}
