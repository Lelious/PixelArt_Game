using UnityEngine;

public class ShowBossHPBar : MonoBehaviour
{
    [SerializeField] private GameObject bossStats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            bossStats.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            bossStats.SetActive(false);
        }
    }
}
