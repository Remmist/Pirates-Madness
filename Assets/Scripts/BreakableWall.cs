using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _currentHealth;
    private bool _isAlive;

    private Animator _animator;

    private void Awake()
    {
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
        _isAlive = true;
    }


    public void TakeDamage(float damage)
    {
        if (!_isAlive)
        {
            return;
        }
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            DestroyWall();
        }
        _animator.SetTrigger("Hit");
    }


    private void DestroyWall()
    {
        _isAlive = false;
        _animator.SetTrigger("Break");
    }
}
