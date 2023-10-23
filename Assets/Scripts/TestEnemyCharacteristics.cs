using UnityEngine;

public class TestEnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    // [SerializeField] private float _damage = 10;
    private bool _isAlive;

    private float _currentHealth;

    private Animator _animator;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("Hurt");
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetTrigger("Dead");
        _isAlive = false;
        // Destroy(gameObject);
        Debug.Log("Enemy die!");
    }

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }
}
