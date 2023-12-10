using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float bounceForce = 25f;
    [SerializeField] private float activateRadius = 2.5f;
    
    private Animator _animator;

    [SerializeField] private AudioSource _audiotrampolin;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Collider2D[] obj = Physics2D.OverlapCircleAll(transform.position, activateRadius, _playerLayer);

        if (obj.Any())
        {
            _animator.SetBool("IsOpen", true);
        }
        else
        {
            _animator.SetBool("IsOpen", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("IsGrounded", false);
            collision.gameObject.GetComponent<Animator>().SetBool("IsAfterJump", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            _audiotrampolin.Play();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, activateRadius);
    }
}