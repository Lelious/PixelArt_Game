using UnityEngine;
using UnityEngine.UI;

public class BossStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image hpBar;

    private float currentHealth;
    private float fill;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        fill = currentHealth/maxHealth;
        hpBar.fillAmount = fill;
    }
    public void TakeDamage(int damage)
    {        
        currentHealth -= damage;
        CheckIsAlive();     
    }
    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            animator.Play("NightBourneDeath");
            gameObject.GetComponent<NightBourneAnimationsController>().enabled = false;
           // gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }
}
