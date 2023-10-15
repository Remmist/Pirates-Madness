using UnityEngine;

public class TestEnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    // [SerializeField] private float _damage = 10;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy die!");
    }
}
