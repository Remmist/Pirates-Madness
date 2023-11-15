using System;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private TestEnemyCharacteristics _enemyCharacteristics;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyCharacteristics = GetComponent<TestEnemyCharacteristics>();
    }
    
    private void FixedUpdate()
    {
        // _animator.SetFloat("XInputAbs", _rb.velocity.magnitude);
        if (_rb.velocity.y < -0.5 && _enemyCharacteristics.IsAlive)
        {
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
        {
            return;
        }
        _animator.SetBool("IsGrounded", true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
        {
            return;
        }
        _animator.SetBool("IsGrounded", false);
    }
}
