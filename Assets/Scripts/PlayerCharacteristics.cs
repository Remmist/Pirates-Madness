using System;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{

    [SerializeField] private PlayerConfig _playerConfig;
    private float _currentHealth;
    private float _currentDamage;
    private float _previousDamage;
    private bool _isStrengthEffect;
    private float _dashDamage;
    private Animator _animator;
    private bool _isAlive;
    [SerializeField] private AudioSource _audioDie;
    [SerializeField] private AudioSource _audioDamage;

    private void Awake()
    {
        _isAlive = true;
        _currentHealth = _playerConfig.BaseHealth;
        _currentDamage = _playerConfig.BaseDamage;
        _dashDamage = _playerConfig.DashDamage;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float takenDamage)
    {
        if (!_isAlive)
        {
            return;
        }
        
        _animator.SetTrigger("Hurt");
        _currentHealth -= takenDamage;

        if (_currentHealth <= 0)
        {
            Die();
        }
        _audioDamage.Play();
    }

    private void Die()
    {
        _isAlive = false;
        _animator.SetTrigger("Dead");
        _audioDie.Play();
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

        _isStrengthEffect = true;
        _previousDamage = _currentDamage;

        if (_currentDamage + strengthAmount > _playerConfig.MaxDamage)
        {
            _currentDamage = _playerConfig.MaxDamage;
            return;
        }

        _currentDamage += strengthAmount;
    }

    public void ReturnStrength()
    {
        _isStrengthEffect = false;
        _currentDamage = _previousDamage;
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

    public float DashDamage
    {
        get => _dashDamage;
        set => _dashDamage = value;
    }

    public bool IsAlive => _isAlive;

    public bool IsStrengthEffect => _isStrengthEffect;

    public PlayerConfig PlayerConfig => _playerConfig;

    public bool IsPlayerAlive => _isAlive;
}
