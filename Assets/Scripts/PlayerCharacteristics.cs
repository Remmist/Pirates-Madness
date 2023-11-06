using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{

    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _currentDamage;
    private Animator _animator;

    private void Awake()
    {
        _currentHealth = _playerConfig.BaseHealth;
        _currentDamage = _playerConfig.BaseDamage;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float takenDamage)
    {
        _animator.SetTrigger("Hurt");
        _currentHealth -= takenDamage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Destroy(gameObject);
        _animator.SetTrigger("Dead");
        Debug.Log("Player die!");
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
        {
            return;
        }

        if (_currentHealth + healAmount > _playerConfig.MaxHealth)
        {
            _currentHealth = _playerConfig.MaxHealth;
            return;
        }

        _currentHealth += healAmount;

    }

    public void IncreaseStrength(int strengthAmount)
    {
        if (strengthAmount < 0)
        {
            return;
        }

        if (_currentDamage + strengthAmount > _playerConfig.MaxDamage)
        {
            _currentDamage = _playerConfig.MaxDamage;
            return;
        }

        _currentDamage += strengthAmount;
    }

    public float Damage
    {
        get => _currentDamage;
        set => _currentDamage = value;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }
}
