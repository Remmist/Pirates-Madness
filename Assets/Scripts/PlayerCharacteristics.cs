using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float damage = 10;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float takenDamage)
    {
        _currentHealth -= takenDamage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player die!");
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }
}
