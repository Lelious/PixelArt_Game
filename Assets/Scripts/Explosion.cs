using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            StartCoroutine(Destroy());
        }
    }
    IEnumerator Destroy()
    {
        explosion.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        explosion.SetActive(false);
    }
}
