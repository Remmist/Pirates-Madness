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
        // if (_rb.velocity != Vector2.zero)
        // {
        //     _animator.SetBool("IsRunning", true);
        // }
        // else
        // {
        //     _animator.SetBool("IsRunning", false);
        // }
        
        if (_rb.velocity.y > 3 && _enemyCharacteristics.IsAlive)
        {
            _animator.SetTrigger("Jump");
            _animator.SetBool("IsGrounded", false); 
        } else if (_rb.velocity.y < -3 && _enemyCharacteristics.IsAlive) 
        { 
            _animator.SetBool("IsFalling", true); 
            _animator.SetBool("IsGrounded", false); 
        }
        else 
        { 
            _animator.SetBool("IsFalling", false); 
            _animator.SetBool("IsGrounded", true); 
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
    //     {
    //         return;
    //     }
    //     _animator.SetBool("IsGrounded", true);
    // }
    //
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (!(other.collider.CompareTag("Ground") || other.collider.CompareTag("BreakablePlatform")))
    //     {
    //         return;
    //     }
    //     _animator.SetBool("IsGrounded", false);
    // }
}
