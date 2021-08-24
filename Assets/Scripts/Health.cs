using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;   
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxMana;
    [SerializeField] private Canvas gameCanvas;

    public int currentMana;

    private HeartSystem heartSystem;
    private Animator _animator;

    private void Awake()
    {      
        heartSystem = gameCanvas.GetComponent<HeartSystem>();
        _animator = GetComponent<Animator>();
        currentMana = _maxMana;
        _currentHealth = _maxHealth;         
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        CheckIsAlive();
        _animator.SetBool("Hit", true);

        if (gameObject.name.Equals("Hero"))
        {
            heartSystem.SetCurrentHealth(_currentHealth);
        }
    }
    private void CheckIsAlive()
    {
        if (_currentHealth <= 0)
        {
            _animator.SetBool("isDead", true);
            gameObject.tag = "Untagged";

            switch (gameObject.name)
            {
                case "Hero":
                    gameObject.GetComponent<PlayerStateAnimations>().enabled = false;
                    _animator.Play("HeroDeath");
                    break;
                case "Skeleton":
                    gameObject.GetComponent<SkeletonController>().enabled = false;
                    gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
                    break;
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  
        }
    }

    public void Hit()
    {
        _animator.SetBool("Hit", false);
        Invoke("EnableDamageable", 1f);
    }

    private void EnableDamageable()
    {
        gameObject.tag = "Damageable";
    }

    public void DecreaseMana()
    {
        currentMana--;
        heartSystem.SetCurrentMana(currentMana);
    }
}
