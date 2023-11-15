using System;
using UnityEngine;

public class TestEnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _repulsionForce = 3f;
    private bool _isAlive = true;

    private float _currentHealth;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _enemyLocalScale = 0f;
    private PlayerSwordCombat _playerSwordCombat;
    private PlayerMovement _playerMovement;

    private void Update()
    {
        _enemyLocalScale = transform.localScale.x;
        if (!IsAlive)
        {
            _animator.SetBool("IsAlive", false);
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerSwordCombat = FindObjectOfType<PlayerSwordCombat>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        if ((_playerSwordCombat.AttackLocalScale < 0 && _enemyLocalScale > 0) ||
            (_playerSwordCombat.AttackLocalScale < 0 && _enemyLocalScale < 0))
        {
            if (_playerMovement.IsDashing)
            {
                _rigidbody.AddForce(new Vector2(-_repulsionForce * 2f, _repulsionForce * 2f), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(-_repulsionForce, _repulsionForce), ForceMode2D.Impulse);
            }
        }
        else 
        // if ((_playerSwordCombat.AttackLocalScale > 0 && _enemyLocalScale < 0) ||
        //     (_playerSwordCombat.AttackLocalScale > 0 && _enemyLocalScale > 0))
        {
            if (_playerMovement.IsDashing)
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
            return;
        }
        _animator.SetTrigger("Hurt");
    }

    private void Die()
    {
        _isAlive = false;
        _animator.SetBool("IsGrounded", false);
        _animator.SetTrigger("Dead");
    }

    public bool IsAlive
    {
        get => _isAlive;
    }
}
