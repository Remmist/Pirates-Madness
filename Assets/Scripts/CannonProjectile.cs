<<<<<<< HEAD
=======
using System;
using System.Collections;
using System.Collections.Generic;
>>>>>>> Aiming_With_Trajectory
using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
<<<<<<< HEAD
    [SerializeField] private float _damage;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject _cannon;
=======
    private Rigidbody2D _rb;
>>>>>>> Aiming_With_Trajectory
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
<<<<<<< HEAD
            //Find new method how to get value from PlayerCharacteristics or TestEnemyCharacteristics
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage);
            }
            else
            {
                other.GetComponent<PlayerCharacteristics>().TakeDamage(_damage);
            }
=======
            Destroy(other.gameObject);
>>>>>>> Aiming_With_Trajectory
            Destroy(gameObject);
        } else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
<<<<<<< HEAD
=======
    
>>>>>>> Aiming_With_Trajectory
}
