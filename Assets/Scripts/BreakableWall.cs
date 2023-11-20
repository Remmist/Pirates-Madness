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
        _animator.SetTrigger("Hit");

        if (_currentHealth <= 0)
        {
            DestroyWall();
        }
    }


    private void DestroyWall()
    {
        _isAlive = false;
        _animator.SetTrigger("Break");
    }
}
