using System;
using UnityEngine;

public class TestEnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _repulsionForce = 3f;
    private bool _isAlive;

    private float _currentHealth;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _enemyLocalScale = 0f;
    private PlayerSwordCombat _playerSwordCombat;

    private void Update()
    {
        _enemyLocalScale = transform.localScale.x;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerSwordCombat = FindObjectOfType<PlayerSwordCombat>();
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("Hurt");
        if ((_playerSwordCombat.AttackLocalScale < 0 && _enemyLocalScale > 0) || (_playerSwordCombat.AttackLocalScale < 0 && _enemyLocalScale < 0))
        {
            if (_playerSwordCombat.GetComponent<PlayerMovement>().IsDashing)
            {
                _rigidbody.AddForce(new Vector2(-_repulsionForce * 2f,_repulsionForce * 2f), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(-_repulsionForce,_repulsionForce), ForceMode2D.Impulse);
            }
        }

        if ((_playerSwordCombat.AttackLocalScale > 0 && _enemyLocalScale < 0) || (_playerSwordCombat.AttackLocalScale > 0 && _enemyLocalScale > 0))
        {
            if (_playerSwordCombat.GetComponent<PlayerMovement>().IsDashing)
            {
                _rigidbody.AddForce(new Vector2(_repulsionForce * 2f,_repulsionForce * 2f), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(_repulsionForce,_repulsionForce), ForceMode2D.Impulse);
            }
        }
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
    }

    public bool IsAlive
    {
        get => _isAlive;
    }
}
