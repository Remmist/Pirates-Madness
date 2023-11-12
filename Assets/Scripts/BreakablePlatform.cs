using System;
using System.Collections;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private float _breakTime = 1f;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Break());
    }

    private IEnumerator Break()
    {
        _animator.SetTrigger("Break");
        yield return new WaitForSeconds(_breakTime);
        Destroy(gameObject);
    }
}
